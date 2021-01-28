using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleListener : MonoBehaviour
{
    
    public ParticleSystem completedParticles;
    
    public void SetPuzzleCompleted(bool t){
        if(t == true){
            completedParticles.Play();
        }
    }
}
