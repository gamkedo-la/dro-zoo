using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cameratransition : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera vcam;
void OnTriggerEnter(Collider other)
    {
        vcam.Priority = 11;
    }


void OnTriggerExit(Collider other)
    {
        vcam.Priority = 9;
    }



}
