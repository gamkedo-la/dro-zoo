using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideIfWebGL : MonoBehaviour
{
    public GameObject[] hideList;
    public bool testHide = false; // check on to test the hiding in Unity

    // Start is called before the fi rame update
    void Start()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer || testHide) {
            for(int i=0;i< hideList.Length;i++) {
                hideList[i].SetActive(false);
            }
        }
    }
}
