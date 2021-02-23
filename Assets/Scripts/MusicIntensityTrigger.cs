using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicIntensityTrigger : MonoBehaviour
{
    public MusicManager musicManager;
    public float intensityGrowthAmount = 0.1f;

    // when you bump into this trigger that is a collider
    private void OnCollisionEnter(Collision other)
    {
        musicManager.intensity += intensityGrowthAmount;
    }

    // if this is just a trigger with no bump
    private void OnTriggerEnter(Collider other)
    {
        musicManager.intensity += intensityGrowthAmount;
    }
    
}
