using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJetController : MonoBehaviour
{
    //this script controls whether the player's thruster particle system is on full or on idle mode based on player movement

    [Header("Main thruster settings:")]
    [SerializeField] private float fullModifier = 2f;
    [SerializeField] private float idleModifier = 1f;
    [SerializeField] private Transform thrusterIdlePositionMarker; //required to move the thruster particles to suitable position when on/off
    [SerializeField] private Transform thrusterFullPositionMarker;
    [SerializeField] float thrusterRepositionSpeed;

    [Header("Side thruster settings:")]
    [SerializeField] float sideThrusterRotationSpeed = 1f;
    [SerializeField] float sideThrusterFullModifier = 2f;
    [SerializeField] float sideThrusterIdleModifier = 1f;
    [SerializeField] float turnVectorXBuffer = .2f;
    [SerializeField] float turnVectorYBuffer = .2f; //buffer for when side thrusters are activated when going up/down

    [Header("Player Input Action Asset:")]
    public InputActionAsset playerControls;

    [Header("Thruster Particle Systems:")]
    public ParticleSystem thrustParticleSystem;
    public ParticleSystem leftThrusterParticleSystem;
    public ParticleSystem rightThrusterParticleSystem;
    
    private InputAction movement;
    private InputAction height;

    private float currentModifier = 1f;
    private float currentSideThrustModifier = 1f;
    private float particleStartSize;
    private float sideThrusterParticleStartSize;
    private Vector3 thrusterIdlePos;
    private Vector3 thrusterFullPos;
    private Vector2 turnVector = Vector2.zero;
    private Vector2 upVector = Vector2.zero;
    private Vector3 leftThrusterStartRotation;
    private Vector3 rightThrusterStartRotation;
    private Vector3 leftThrusterTargetRotation;
    private Vector3 rightThrusterTargetRotation;
    private float thrusterPositionDistance;
    private float startTime;
    private bool isMovementInput = false;
    private bool isHeightInput = false;
    private bool isMoving = false;
    


    private void OnEnable() {
        if(playerControls){
        movement = playerControls.FindActionMap("PlayerControl").FindAction("PlayerMovement");
        movement.started += OnPlayerMovementStarted;
        movement.performed += OnPlayerMovement;
        movement.canceled += OnPlayerMovementCanceled;
        movement.Enable();
        height = playerControls.FindActionMap("PlayerControl").FindAction("PlayerHeight");
        height.started += OnPlayerHeightStarted;
        height.performed += OnPlayerHeight;
        height.canceled += OnPlayerHeightCanceled;
        height.Enable();
        } else {
            Debug.LogWarning("Thruster Controller script in " + gameObject.name + " could not find a InputActionAsset");
        }
    }

    private void OnDisable() {
        movement.Disable();
        height.Disable();
    }

    private void OnPlayerMovementStarted(InputAction.CallbackContext context){
        startTime = Time.time;
    }

    private void OnPlayerMovement(InputAction.CallbackContext context){
        isMovementInput = true;
        upVector = context.ReadValue<Vector2>();
    }

    private void OnPlayerMovementCanceled(InputAction.CallbackContext context){
        startTime = Time.time;
        isMovementInput = false;
    }

    private void OnPlayerHeightStarted(InputAction.CallbackContext context){
        startTime = Time.time;
    
    }

    private void OnPlayerHeight(InputAction.CallbackContext context){
        isHeightInput = true;
        turnVector = context.ReadValue<Vector2>();
        
    }

    private void OnPlayerHeightCanceled(InputAction.CallbackContext context){
        isHeightInput = false;
        startTime = Time.time;
       
    }

    private void Start() {
        if(thrustParticleSystem == null){
            Debug.LogWarning("PlayerJetController script was unable to find a Particle System attached");
        } else {
            particleStartSize = thrustParticleSystem.main.startSize.constant; //assuming that the particle system start size is a constant!
        }
        if(leftThrusterParticleSystem == null){
            Debug.LogWarning("PlayerJetController script was unable to find a left thruster particle system!");
        } else {
            sideThrusterParticleStartSize = leftThrusterParticleSystem.main.startSize.constant; //assuming that the particle system start size is a constant!
        }
        startTime = Time.time;
        thrusterPositionDistance = Vector3.Distance(thrusterFullPos, thrusterIdlePos);

        //get start rotations of side thrusters to default to if no turning is detected
        leftThrusterStartRotation = leftThrusterParticleSystem.gameObject.transform.rotation.eulerAngles;
        rightThrusterStartRotation = rightThrusterParticleSystem.gameObject.transform.rotation.eulerAngles;

    }

    private void Update() {
        isMoving = isMovementInput || isHeightInput ? true : false;
        HandleThrustModifier();
        HandleSideThrustModifier();

        PositionMainThruster(thrustParticleSystem.gameObject.transform.position);
        ScaleThruster(thrustParticleSystem, HandleThrustModifier(), particleStartSize);
        ScaleThruster(leftThrusterParticleSystem, HandleSideThrustModifier(), sideThrusterParticleStartSize);
        ScaleThruster(rightThrusterParticleSystem, HandleSideThrustModifier(), sideThrusterParticleStartSize);
        
        RotateSideThrusters();
    }

    private void PositionMainThruster(Vector3 currentPos)
    {
        thrusterFullPos = thrusterFullPositionMarker.position;
        thrusterIdlePos = thrusterIdlePositionMarker.position;

        float distCovered = (Time.time - startTime) * thrusterRepositionSpeed;
        float fractionOfDist = distCovered / Vector3.Distance(thrusterFullPos, thrusterIdlePos);

        if(isMoving && (turnVector.y > 0 || upVector != Vector2.zero) && thrustParticleSystem.gameObject.transform.position != thrusterFullPos){ //going upwards or sideways, then thruster is on
            thrustParticleSystem.gameObject.transform.position = Vector3.Lerp(thrusterIdlePos, thrusterFullPos, fractionOfDist);
        } else if(!isMoving && transform.position != thrusterIdlePos){
            thrustParticleSystem.gameObject.transform.position = Vector3.Lerp(thrusterFullPos, thrusterIdlePos, fractionOfDist);
        }
    }

    private float HandleThrustModifier()
    {
        if(isMoving && (turnVector.y > 0 || upVector != Vector2.zero)){
            currentModifier = fullModifier;
        } else {
            currentModifier = idleModifier;
        }

        return currentModifier;
    }

    private float HandleSideThrustModifier(){
        if(isHeightInput && (Math.Abs(turnVector.x) > turnVectorXBuffer) || turnVector.y > turnVectorYBuffer){
            currentSideThrustModifier = sideThrusterFullModifier;
        } else {
            currentSideThrustModifier = sideThrusterIdleModifier;
        }

        return currentSideThrustModifier;
    }

    private void RotateSideThrusters(){
        //rotate thruster 90 degrees from start position if height input's x values change.
        if(isHeightInput && Mathf.Abs(turnVector.x) > turnVectorXBuffer){
            if(turnVector.x < 0){
                //left thruster to 180 in x
                leftThrusterTargetRotation = new Vector3(180, 0, 0);
                rightThrusterTargetRotation = new Vector3(0, 0, 0);
            } else if (turnVector.x > 0){
                leftThrusterTargetRotation = new Vector3(0, 0, 0);
                rightThrusterTargetRotation = new Vector3(180, 0, 0);
            } 
            leftThrusterParticleSystem.transform.localRotation = Quaternion.Lerp(
                leftThrusterParticleSystem.transform.localRotation,
                Quaternion.Euler(leftThrusterTargetRotation.x, leftThrusterTargetRotation.y, leftThrusterTargetRotation.z),
                Time.deltaTime * sideThrusterRotationSpeed);

            rightThrusterParticleSystem.transform.localRotation = Quaternion.Lerp(
                rightThrusterParticleSystem.transform.localRotation,
                Quaternion.Euler(rightThrusterTargetRotation.x, rightThrusterTargetRotation.y, rightThrusterTargetRotation.z),
                Time.deltaTime * sideThrusterRotationSpeed);
            }

        if(!isHeightInput){
                leftThrusterParticleSystem.transform.localRotation = Quaternion.Lerp(
                leftThrusterParticleSystem.transform.localRotation,
                Quaternion.Euler(leftThrusterStartRotation.x, leftThrusterStartRotation.y, leftThrusterStartRotation.z),
                Time.deltaTime * sideThrusterRotationSpeed);

                rightThrusterParticleSystem.transform.localRotation = Quaternion.Lerp(
                rightThrusterParticleSystem.transform.localRotation,
                Quaternion.Euler(rightThrusterStartRotation.x, rightThrusterStartRotation.y, rightThrusterStartRotation.z),
                Time.deltaTime * sideThrusterRotationSpeed);
        }
        
        
        
    }

    private void ScaleThruster(ParticleSystem thruster, float modifier, float startSize){
        var main = thruster.main;
        main.startSize = modifier * startSize;
    }

}
