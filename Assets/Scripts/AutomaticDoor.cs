using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDoor : MonoBehaviour
{

    public GameObject leftDoor;
    public GameObject rightDoor;

    public float openSpeed = 1f;
    public bool open = false;
    private Vector3 originalRightDoorPosition;
    private Vector3 originalLeftDoorPosition;
    [SerializeField] public PowerUp powerUp; // changed from private to public class reference 
    public bool isPoweredUp; // added by zac 
    // Start is called before the first frame update
    void Start()
    {
        originalRightDoorPosition = rightDoor.transform.position;
        originalLeftDoorPosition = leftDoor.transform.position;
    }

    // zac code 
    private void NullCheck()
    {
        if(powerUp == null)
        {
            return; 
        }
        else if(powerUp != null)
        {
            powerUp = FindObjectOfType<PowerUp>(); 
        }
    }
    // end zac code 

    // Update is called once per frame
    void Update()
    {
        if(open){
            Vector3 rightTarget = new Vector3(gameObject.GetComponent<Renderer>().bounds.max.x, rightDoor.transform.position.y, gameObject.GetComponent<Renderer>().bounds.max.z);
            Vector3 leftTarget = new Vector3(gameObject.GetComponent<Renderer>().bounds.min.x, rightDoor.transform.position.y, gameObject.GetComponent<Renderer>().bounds.min.z);
            rightDoor.transform.position = Vector3.MoveTowards(rightDoor.transform.position, rightTarget, openSpeed);
            leftDoor.transform.position = Vector3.MoveTowards(leftDoor.transform.position, leftTarget, openSpeed);
        } else if(!open){
            if(powerUp != null) // added by zac 
            {
                powerUp.GetIsActivated(); 
            } // end added by zac 
            rightDoor.transform.position = Vector3.MoveTowards(rightDoor.transform.position, originalRightDoorPosition, openSpeed);
            leftDoor.transform.position = Vector3.MoveTowards(leftDoor.transform.position, originalLeftDoorPosition, openSpeed);
        }
        return; 
    }

    // modified by zac 
    private void OnTriggerEnter(Collider other) // maybe have puzzle completed condition trigger the door's? 
    {
        if(powerUp != null)
        {
            if (powerUp.GetIsActivated() && powerUp.isPowerUpActivated.Equals(true)
           || isPoweredUp.Equals(true))
            {
                Debug.Log(gameObject.GetComponent<Renderer>().bounds.max);
                Debug.Log("You are on the collider");
                open = true;
            }
            else if (powerUp == null)
            {
                Debug.Log("You need to assign Power Up into missing Field" + powerUp);
                return;
            }
        }
    }
    // end modified by zac 
    
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("You left the collider");
        open = false;
    }
}
