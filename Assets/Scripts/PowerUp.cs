using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    [Header("Power Up settings:")]
    [Tooltip("Is the power up triggered once or over time")]
    [SerializeField] private bool isTriggeredOverTime = false;
    [SerializeField] private int overTimeIncrement = 0;
    [Tooltip("Seconds to stay in trigger")]
    [SerializeField] private float triggerTimerInSeconds = 1;
    [Tooltip("Times needed to trigger")]
    [SerializeField] private int maxTimesUsed = 5;
    //[Tooltip("Seconds to reset the power up for reuse")]
    //[SerializeField] private float resetTime = 10f;

    [Header("Trigger Collider Settings:")]
    [SerializeField] Collider triggerCollider;

    [Header("Object Controlled By Trigger")]
    [SerializeField] GameObject objectToTrigger;

    private GameObject player;
    private bool playerIsInTrigger = false;
    private bool isEnterLeft = false;
    private bool isExitLeft = false;
    //private float enterTime = 0f;
    public int timesUsed {
        get {return timesUsed;}
    }
    private float exitTime = 0f;
    public int currentPowerLevel {
        get {return powerLevel;}
        set {powerLevel = value;}
    }
    private bool isActivated;

    private int powerLevel = 0;


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
        //enterTime = Time.time;
        isEnterLeft = CheckMovementDirection(other.gameObject);
        if(isTriggeredOverTime){
            StartCoroutine("PowerUpCycle");
        }
    }

    private void OnTriggerExit(Collider other) {
        //on entering trigger, set time when the player entered it, if the player has reached the maximum amount of uses
        playerIsInTrigger = false;
        isActivated = false;
        isExitLeft = CheckMovementDirection(other.gameObject);
        ResetPowerLevel();
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
}
