using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dockcable : MonoBehaviour
{
    
    [SerializeField]
    private GameObject endcable;
    [SerializeField]
    private GameObject plant1;
    [SerializeField]
    private GameObject plant2;

       
    private void OnTriggerEnter(Collider other)
    {
        endcable.GetComponent<Followplayer>().enabled = false;
        plant1.GetComponent<Animator>().SetTrigger("Grow");
        plant2.GetComponent<Animator>().SetTrigger("Grow");
    }
}
