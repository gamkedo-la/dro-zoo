using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public enum PowerUpRequiredDirection {leftToRight, rightToLeft}

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
    [Tooltip("Set required direction for moving through PowerUp")]
    [SerializeField] bool isDirectionRequired;
    [Tooltip("Required direction relative to camera")]
    public PowerUpRequiredDirection powerUpRequiredDirection;
    [Header("Trigger Collider Settings:")]
    [SerializeField] Collider triggerCollider;

    [Header("Object Controlled By Trigger")]
    [SerializeField] GameObject objectToTrigger;

    [SerializeField] private AutomaticDoor door; // added reference by zac 

    private GameObject player;
    private bool playerIsInTrigger = false;
    //public bool isEnterLeft = false;
    //public bool isExitLeft = false;
    //private float enterTime = 0f;
    private Vector2 exitDirection;
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
        if(isTriggeredOverTime){
            StartCoroutine("PowerUpCycle");
        }
        if(isPartOfSequence && !isDirectionRequired){
            //the powerup is successfully activated when it is triggered
            HandleSequencePuzzleActivation(true);
        }
        if(showAnimationsForPlayer){
            //if more control for showing an animation for the Player object is required, add conditions here
            if(other.GetComponentInChildren<PlayerAnimationHandler>() != null){
                other.GetComponentInChildren<PlayerAnimationHandler>().HandlePowerUpAnimation(true);
            } else {
                Debug.LogWarning("PowerUp " + name + " tried to access the colliding objects animation handler, but did not find one");
            }
            
        }

        // begin zac code 
        if(isActivated.Equals(true) && door.open.Equals(false))
        {
            door.isPoweredUp = true; // this sets powered up bool to true, then Automatic Door checks if it's true
            door.open.Equals(true); 
            return; 
        }
        // end zac code 
    }

    private void OnTriggerExit(Collider other) {
        //on entering trigger, set time when the player entered it, if the player has reached the maximum amount of uses
        playerIsInTrigger = false;
        isActivated = false;
        exitDirection = CheckMovementDirection(other.gameObject);
        ResetPowerLevel();
        if(showAnimationsForPlayer){
            if(other.GetComponentInChildren<PlayerAnimationHandler>() != null){
                other.GetComponentInChildren<PlayerAnimationHandler>().HandlePowerUpAnimation(false);
            } else {
                Debug.LogWarning("PowerUp " + name + " tried to access the colliding objects animation handler, but did not find one");
            }
        }
        if(isDirectionRequired){
            HandleMovementDirection();
        }
    }

    private void OnTriggerStay(Collider other) {
        playerIsInTrigger = true;
    }

    private void NullCheck() // zac code 
    {
        if(door == null || door.powerUp == null)
        {
            return; 
        }
    }

    private void Update()
    {
        NullCheck(); 
    } // end zac code 

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

    private void HandleMovementDirection()
    {
        //if the movement direction matches to the set direction, consider this powerup activated and signal for successful activation
        Vector2 dir = GetMovementDirection();
        if(dir == Vector2.left && powerUpRequiredDirection.ToString() == "leftToRight"){
            if(isPartOfSequence){
                HandleSequencePuzzleActivation(true);
            }
        } else if (dir == Vector2.right && powerUpRequiredDirection.ToString() == "rightToLeft"){
            if(isPartOfSequence){
                HandleSequencePuzzleActivation(true);
            }
        } else {
            HandleSequencePuzzleActivation(false);
        }
    }


    private Vector2 CheckMovementDirection(GameObject obj)
    {
        // when called, check the direction to object in parameter. Boolean given tells if the colliding object is to the left of object
        Vector3 relativeDirection = this.transform.InverseTransformVector(obj.transform.position - this.transform.position);
        if(relativeDirection.z > 0){
            return Vector2.left;
        } else {
            return Vector2.right;
        }
    }

    /// <summary>
     /// Returns Vector2 depicting direction of movement in and out of the trigger.
     /// Only takes into account movement through the trigger.
     /// </summary>
     /// <returns>Returns normalized Vector2 left/right.</returns>
    public Vector2 GetMovementDirection(){
        return exitDirection;
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

    private void HandleSequencePuzzleActivation(bool isCorrect){
        //used to inform the parent Puzzle handler that this trigger was successfully activated
        PowerUpSequencePuzzle puzzle = GetComponentInParent<PowerUpSequencePuzzle>();
        if(!puzzle || puzzle == null){
            Debug.LogWarning("PowerUp " + name + " was unable to locate power up puzzle sequence handler when activated");
        } else {
            puzzle.HandlePowerUpActivated(gameObject.GetComponent<PowerUp>(), isCorrect);
        }       
    }
}
