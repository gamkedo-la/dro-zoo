using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorBehavior_ZacB : MonoBehaviour
{
    public GameObject Door01L;
    public GameObject Door01R; 
    public Transform doorLPos;
    public Transform doorRPos;
    public GameObject door01LOrigin;
    public GameObject door01ROrigin; 

    public Transform openPos;
    public Transform closePos;
    public GameObject Door02;

    public float doorSpeed = 0.5f;

    private void Awake()
    {
        doorSpeed = 0.5f; 
    }

    private void OnTriggerStay(Collider other)
    {
        if(gameObject.name == "Door_01_ZacB_v02_Prefab")
        {
            StartCoroutine(OpenDoor01());
        }
        else if(gameObject.name == "Door_02_ZacB_Prefab")
        {
            StartCoroutine(OpenDoor02()); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (gameObject.name == "Door_01_ZacB_v02_Prefab")
        {
            StartCoroutine(CloseDoor01());
        }
        else if (gameObject.name == "Door_02_ZacB_Prefab")
        {
            StartCoroutine(CloseDoor02()); 
        }
    }

    IEnumerator OpenDoor01()
    {
        float step = doorSpeed * Time.deltaTime;
        Door01L.transform.position = Vector3.MoveTowards(Door01L.transform.position, doorLPos.transform.position, step);
        Door01R.transform.position = Vector3.MoveTowards(Door01R.transform.position, doorRPos.transform.position, step);
        yield return null; 
    }

    IEnumerator CloseDoor01()
    {
        Door01L.transform.position = door01LOrigin.transform.position;
        Door01R.transform.position = door01ROrigin.transform.position; 
        yield return null; 
    }

    IEnumerator OpenDoor02()
    {
        float step = doorSpeed * Time.deltaTime;
        Door02.transform.position = Vector3.MoveTowards(Door02.transform.position, closePos.transform.position, step);
        yield return null;
    }

    IEnumerator CloseDoor02()
    {
        Door02.transform.position = openPos.transform.position;
        yield return null;
    }
}