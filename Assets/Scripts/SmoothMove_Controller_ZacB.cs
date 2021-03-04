using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothMove_Controller_ZacB : MonoBehaviour
{
    [SerializeField] private SmoothMovement_Test_ZacB moveController;
    public bool isMovementInput; 

    private void Update()
    {
        if (isMovementInput) // Inheritence from Movement Controller // ZacB 
        {
            moveController.OnSmoothMovemnt();
        }
    }
}