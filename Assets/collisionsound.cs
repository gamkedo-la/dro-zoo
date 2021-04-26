using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionsound : MonoBehaviour {

    public AudioSource selectedSound;

    private void OnCollisionEnter(Collision other) {
        if (selectedSound) {
            selectedSound.Play();
        } else {
            GetComponent<AudioSource>().Play();
        }
    }

}
