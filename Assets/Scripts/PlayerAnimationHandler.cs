using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimationHandler : MonoBehaviour
{

    [Header("Player Input Action Asset:")]
    public InputActionAsset playerControls;
    [Header("Components from Player")]
    [SerializeField] Animator playerAnim;
    //[SerializeField] GameObject playerMesh; //animate on the mesh level in order to not mess with movement
    //[SerializeField] GameObject playerParent;
    [Header("Idle animation settings:")]
    [SerializeField] float timeBeforeIdleInSeconds = 5f;

    private Camera mainCamera;
    private bool isIdle = false;
    private bool isInput = false;
    private bool idleTimerStarted = false;
    private float startTime;

    private InputAction movement;
    private InputAction height;

    private void OnEnable() {
        if(playerControls){
        movement = playerControls.FindActionMap("PlayerControl").FindAction("PlayerMovement");
        movement.started += OnPlayerMovementStarted;
        movement.canceled += OnPlayerMovementCanceled;
        movement.Enable();
        height = playerControls.FindActionMap("PlayerControl").FindAction("PlayerHeight");
        height.started += OnPlayerHeightStarted;
        height.canceled += OnPlayerHeightCanceled;
        height.Enable();
        } else {
            Debug.LogWarning("Thruster Controller script in " + gameObject.name + " could not find a InputActionAsset");
        }
    }

    private void OnPlayerHeightCanceled(InputAction.CallbackContext obj)
    {
        isInput = false;
    }

    private void OnPlayerHeightStarted(InputAction.CallbackContext obj)
    {
        isInput = true;
    }

    private void OnPlayerMovementCanceled(InputAction.CallbackContext obj)
    {
        //start coroutine to set idle to true
        isInput = false;
    }

    private void OnPlayerMovementStarted(InputAction.CallbackContext obj)
    {
        isInput = true;
    }

    private void OnDisable() {
        movement.Disable();
        height.Disable();
    }



    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        if(isInput){
            isIdle = false;
            SetIsIdleInAnimator(isIdle);
        }

        //if there is input and timer has been started, reset timer started bool to false
        if(isInput && idleTimerStarted){
            idleTimerStarted = false;
            
        }
        //if there has been no input, start timer for starting idle animation if it has not already been started
        if(!isInput && !idleTimerStarted){
            startTime = Time.time;
            idleTimerStarted = true;
           
        }

        if(idleTimerStarted && Time.time - startTime >= timeBeforeIdleInSeconds){
            isIdle = true;
            SetIsIdleInAnimator(isIdle);
        }

    }

    private void SetIsIdleInAnimator(bool isIdle)
    {
        playerAnim.SetBool("IsIdle", isIdle);
    }
}
