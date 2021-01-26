using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    [Header("Power Up settings:")]
    [Tooltip("Is the power up triggered once or over time")]
    [SerializeField] private bool isTriggeredOverTime = false;
    [Tooltip("Seconds to give payload again")]
    [SerializeField] private float triggerTimerInSeconds = 1;
    [SerializeField] private int maxTimesUsed = 5;
    [Tooltip("Seconds to reset the power up for reuse")]
    [SerializeField] private float resetTime = 10f;

    [Header("Trigger Collider Settings:")]
    [SerializeField] Collider triggerCollider;

    private GameObject player;
    private bool playerIsInTrigger = false;
    private bool needsToReset = false;
    public float enterTime = 0f;
    public float previousEnterTime = 0f;
    public int timesUsed = 0;
    public float exitTime = 0f;



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
        enterTime = Time.time;
        CheckForReset(enterTime);
        playerIsInTrigger = true;
        if(!isTriggeredOverTime){
            PowerUpPayload();
        } else {
            StartCoroutine(PowerUpCycle(triggerTimerInSeconds, triggerCollider));
        }
        
    }

    IEnumerator PowerUpCycle(float triggerTimerInSeconds, Collider triggerCollider)
    {
        while (playerIsInTrigger){
            PowerUpPayload();
            yield return new WaitForSeconds(triggerTimerInSeconds);
        }
    }

    private void OnTriggerExit(Collider other) {
        playerIsInTrigger = false;
        //if all uses are used up, needs to reset
        if(timesUsed == maxTimesUsed){
            needsToReset = true;
        }
        if(!needsToReset){
            exitTime = Time.time;
        }
    }

    public void PowerUpPayload(){
        //override this method to provide a payload to the player from the powerup
        if(timesUsed < maxTimesUsed){
            Debug.Log("Payload given!");
            timesUsed ++;
        }
    }

    private void CheckForReset(float enterTime)
    {
        //if player re-enters the trigger at time 20f, and has exited the trigger at 15f, we do not yet reset the powerup
        if(enterTime - exitTime > resetTime){
            Debug.Log("Reset power up!");
            timesUsed = 0;
            needsToReset = false;
        }
    }

}
