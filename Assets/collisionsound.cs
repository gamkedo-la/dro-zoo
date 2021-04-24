using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionsound : MonoBehaviour
{
    




    private void OnCollisionEnter(Collision other) {
    
    GetComponent<AudioSource> ().Play ();
}


}
