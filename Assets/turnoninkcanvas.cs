using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnoninkcanvas : MonoBehaviour
{
    
    [SerializeField]
    private Canvas inkcanvas;
void OnTriggerEnter(Collider other)
    {
        inkcanvas.enabled = true;
        Debug.Log("inkcanvas should be enabled");
    }

/* void OnTriggerExit(Collider other)
    {
        inkcanvas.enabled = false;
    } */

}
