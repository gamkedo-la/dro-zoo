using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideTouchIfWebGL : MonoBehaviour
{
    public GameObject leftDot;
    public GameObject rightDot;
    public bool testHide = false; // check on to test the hiding in Unity

    // Start is called before the first frame update
    void Start()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer || testHide) {
            leftDot.SetActive(false);
            rightDot.SetActive(false);
        }
    }
}
