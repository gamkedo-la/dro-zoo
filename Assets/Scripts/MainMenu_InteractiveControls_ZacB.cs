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
    [SerializeField] public InputAction inputAction;
    [SerializeField] public PlayerInput playerInput;
    [SerializeField] public InputActionMap playerActions; 
    [SerializeField] public LoadMenus_Manager_ZacB lmM;

    private void Start()
    {
        startGame = false; 
        inputAction = new InputAction(type: InputActionType.Button);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            startGame = true;
            ChangeColor();
            return; 
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            // Debug.Log("Player Staying in Trigger");

            if(startGame == true)
            {
                SendMessage("OnSubmit", SendMessageOptions.DontRequireReceiver);
                return; 
            }
        }
    }

    private void ChangeColor()
    {
       // Debug.Log("Changed Color of Start Button");
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
        if(playerInput == null)
        {
            return; 
        }
    }
}