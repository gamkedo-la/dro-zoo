using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJetController : MonoBehaviour
{
    //this script controls whether the player's thruster particle system is on full or on idle mode based on player movement

    [SerializeField] private float fullModifier = 2f;
    [SerializeField] private float idleModifier = 1f;
    [SerializeField] private Transform thrusterIdlePositionMarker; //required to move the thruster particles to suitable position when on/off
    [SerializeField] private Transform thrusterFullPositionMarker;
    [SerializeField] float thrusterRepositionSpeed;
    public InputActionAsset playerControls;
    private InputAction movement;
    private InputAction height;

    private float currentModifier = 1f;
    private float particleStartSize;
    private Vector3 thrusterIdlePos;
    private Vector3 thrusterFullPos;
    private float thrusterPositionDistance;
    private float startTime;
    private bool isMovementInput = false;
    private bool isHeightInput = false;
    private bool isMoving = false;
    private ParticleSystem thrustParticleSystem;


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
    }

    private void OnPlayerHeightCanceled(InputAction.CallbackContext context){
        isHeightInput = false;
        startTime = Time.time;
    }

    private void Start() {
        thrustParticleSystem = GetComponent<ParticleSystem>();
        if(thrustParticleSystem == null){
            Debug.LogWarning("ThrustController script was unable to find a Particle System attached");
        } else {
            particleStartSize = thrustParticleSystem.main.startSize.constant; //assuming that the particle system start size is a constant!
        }
        startTime = Time.time;


        thrusterPositionDistance = Vector3.Distance(thrusterFullPos, thrusterIdlePos);

    }

    private void Update() {
        isMoving = isMovementInput || isHeightInput ? true : false;
        HandleThrustModifier();
        RepositionThruster(transform.position);
        var main = thrustParticleSystem.main;
        main.startSize = currentModifier * particleStartSize;

    }

    private void RepositionThruster(Vector3 currentPos)
    {
        thrusterFullPos = thrusterFullPositionMarker.position;
        thrusterIdlePos = thrusterIdlePositionMarker.position;

        float distCovered = (Time.time - startTime) * thrusterRepositionSpeed;
        float fractionOfDist = distCovered / Vector3.Distance(thrusterFullPos, thrusterIdlePos);

        if(isMoving && transform.position != thrusterFullPos){
            transform.position = Vector3.Lerp(thrusterIdlePos, thrusterFullPos, fractionOfDist);
        } else if(!isMoving && transform.position != thrusterIdlePos){
            transform.position = Vector3.Lerp(thrusterFullPos, thrusterIdlePos, fractionOfDist);
        }

    }

    private void HandleThrustModifier()
    {
        if(isMoving){
            currentModifier = fullModifier;
        } else {
            currentModifier = idleModifier;
        }
    }
}
