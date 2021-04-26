using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLoadMixerForWeb : MonoBehaviour
{
    private Object AMGO;
    // Start is called before the first frame update
    void Start()
    {
        AMGO = Resources.Load("LevelScene");
        if(AMGO) {
            Debug.Log("** loaded AudioMixer!");
        } else {
            Debug.Log("** could not load AudioMixer!");
        }
    }
}
