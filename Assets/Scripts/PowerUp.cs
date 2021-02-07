using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PowerUp : MonoBehaviour
{

    [Header("Power Up settings:")]
    [Tooltip("Is the power up triggered once or over time")]
    [SerializeField] private bool isTriggeredOverTime = false;
    [SerializeField] private int overTimeIncrement = 0;
    [SerializeField] public bool isPartOfSequence = false;
    [Tooltip("Seconds to stay in trigger")]
    [SerializeField] private float triggerTimerInSeconds = 1;
    [Tooltip("Times needed to trigger")]
    [SerializeField] private int maxTimesUsed = 5;
    //[Tooltip("Seconds to reset the power up for reuse")]
    //[SerializeField] private float resetTime = 10f;
    [Tooltip("Will trigger collision start animations in Player")]
    [SerializeField] private bool showAnimationsForPlayer = true;

    [Header("Trigger Collider Settings:")]
    [SerializeField] Collider triggerCollider;

    [Header("Object Controlled By Trigger")]
    [SerializeField] GameObject objectToTrigger;

    private GameObject player;
    private bool playerIsInTrigger = false;
    private bool isEnterLeft = false;
    private bool isExitLeft = false;
    //private float enterTime = 0f;
    private int timesUsed;
    public int timesPowerUpUsed {
        get {return timesUsed;}
    }
    private float exitTime = 0f;
    private int powerLevel = 0;
    public int currentPowerLevel {
        get {return powerLevel;}
        set {powerLevel = value;}
    }
    private bool isActivated;
    public bool isPowerUpActivated{
        get {return isActivated;}
        set {isActivated = value;}
    }


    private void Start() {
        player = FindObjectOfType<MovementController>().gameObject;
        if(!player || player == null){
            Debug.LogWarning("PowerUp " + gameObject.name +  " was not able to find player object");
        }

        if(!triggerCollider){
            Debug.LogWarning("PowerUp" + gameObject.name + " has no collider attached to the script");
        }
    }

    private void OnTriggerEnter(Collider other) {
        //on entering trigger, set time when the player entered it, if the player has reached the maximum amount of uses
        playerIsInTrigger = true;
        isActivated = true;
        isEnterLeft = CheckMovementDirection(other.gameObject);
        if(isTriggeredOverTime){
            StartCoroutine("PowerUpCycle");
        }
        if(isPartOfSequence){
            HandleSequencePuzzleActivation();
        }
        if(showAnimationsForPlayer){
            //if more control for showing an animation for the Player object is required, add conditions here
            if(other.GetComponentInChildren<PlayerAnimationHandler>() != null){
                other.GetComponentInChildren<PlayerAnimationHandler>().HandlePowerUpAnimation(true);
            } else {
                Debug.LogWarning("PowerUp " + name + " tried to access the colliding objects animation handler, but did not find one");
            }
            
        }
    }

    private void OnTriggerExit(Collider other) {
        //on entering trigger, set time when the player entered it, if the player has reached the maximum amount of uses
        playerIsInTrigger = false;
        isActivated = false;
        isExitLeft = CheckMovementDirection(other.gameObject);
        ResetPowerLevel();
        if(showAnimationsForPlayer){
            if(other.GetComponentInChildren<PlayerAnimationHandler>() != null){
                other.GetComponentInChildren<PlayerAnimationHandler>().HandlePowerUpAnimation(false);
            } else {
                Debug.LogWarning("PowerUp " + name + " tried to access the colliding objects animation handler, but did not find one");
            }
        }
    }

    private void OnTriggerStay(Collider other) {
        playerIsInTrigger = true;
    }

    IEnumerator PowerUpCycle()
    {
        while (playerIsInTrigger){
            powerLevel = powerLevel + overTimeIncrement;
            yield return new WaitForSeconds(triggerTimerInSeconds);
        }
    }

    private void ResetPowerLevel(){
        powerLevel = 0;
    }

    private bool CheckMovementDirection(GameObject obj)
    {
        // when called, check the direction to object in parameter. Boolean given tells if the object is triggered from the left on exit/enter
        Vector3 direction = (obj.transform.position - this.transform.position).normalized;
        bool isTriggeredFromLeft;
        if(direction.x > 0){
            isTriggeredFromLeft = false;
        } else {
            isTriggeredFromLeft = true;
        }
        return isTriggeredFromLeft;
    }

    /// <summary>
     /// Returns Vector2 depicting direction of movement in and out of the trigger.
     /// Only takes into account movement through the trigger.
     /// </summary>
     /// <returns>Returns normalized Vector2 left/right.</returns>
    public Vector2 GetMovementDirection(){
        Vector2 movementDirection = Vector2.zero;
        if(isEnterLeft && !isExitLeft){ //left to right -> return right
            movementDirection = Vector2.right;
        } else if (!isEnterLeft && isExitLeft) { //right to left -> return left
            movementDirection = Vector2.left;
        }
        return movementDirection;
    }

    /// <summary>
     /// Returns true if the powerup has been triggered the maximum times used.
     /// </summary>
     /// <returns>Returns true if the powerup has been triggered the maximum times used.</returns>
    public bool MaximumTimesUsedReached(){
        return timesUsed >= maxTimesUsed;
    }
    
    public float GetExitTime(){
        return exitTime;
    }

    public bool GetIsActivated(){
        return isActivated;
    }

    private void HandleSequencePuzzleActivation(){
        //used to inform the parent Puzzle handler that this trigger was successfully activated
        PowerUpSequencePuzzle puzzle = GetComponentInParent<PowerUpSequencePuzzle>();
        if(!puzzle || puzzle == null){
            Debug.LogWarning("PowerUp " + name + " was unable to locate power up puzzle sequence handler when activated");
        } else {
            puzzle.HandlePowerUpActivated(gameObject.GetComponent<PowerUp>());
        }       
    }
}
