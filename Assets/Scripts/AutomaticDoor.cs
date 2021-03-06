using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDoor : MonoBehaviour
{

    public GameObject leftDoor;
    public GameObject rightDoor;

    public float openSpeed = 1f;
    private bool open = false;
    private Vector3 originalRightDoorPosition;
    private Vector3 originalLeftDoorPosition;
    // Start is called before the first frame update
    void Start()
    {
        originalRightDoorPosition = rightDoor.transform.position;
        originalLeftDoorPosition = leftDoor.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(open){
            Vector3 rightTarget = new Vector3(gameObject.GetComponent<Renderer>().bounds.max.x, rightDoor.transform.position.y, gameObject.GetComponent<Renderer>().bounds.max.z);
            Vector3 leftTarget = new Vector3(gameObject.GetComponent<Renderer>().bounds.min.x, rightDoor.transform.position.y, gameObject.GetComponent<Renderer>().bounds.min.z);
            rightDoor.transform.position = Vector3.MoveTowards(rightDoor.transform.position, rightTarget, openSpeed);
            leftDoor.transform.position = Vector3.MoveTowards(leftDoor.transform.position, leftTarget, openSpeed);
        } else if(!open){
            rightDoor.transform.position = Vector3.MoveTowards(rightDoor.transform.position, originalRightDoorPosition, openSpeed);
            leftDoor.transform.position = Vector3.MoveTowards(leftDoor.transform.position, originalLeftDoorPosition, openSpeed);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject.GetComponent<Renderer>().bounds.max);
        Debug.Log("You are on the collider");
        open = true;
    }
    
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("You left the collider");
        open = false;
    }
}
