using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dockcable : MonoBehaviour
{
    
    [SerializeField]
    private GameObject endcable;

       
    private void OnTriggerEnter(Collider other)
    {
        endcable.GetComponent<Followplayer>().enabled = false;
    }
}
