using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.InputSystem; 
using TMPro; 
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MainMenu_InteractiveControls_ZacB : MonoBehaviour
{
   [SerializeField] public Button startButton;
    public bool startGame; 

    private void OnTriggerEnter(Collider other)
    {
        startGame = true; 
        if(other.gameObject.CompareTag("Player"))
        {
            ChangeColor();
            return; 
        }
    }

    private void ChangeColor()
    {
        Debug.Log("Changed Color of Start Button");
        startButton.image.color = new Color(0.06968674f, 0.8207547f, 0.1056913f, 1f); 
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            startButton.image.color = new Color(1, 1, 1, 1); 
            return;
        }
    }

    private void Update()
    {
       // set Input params 
    }
}
