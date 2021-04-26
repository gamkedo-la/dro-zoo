using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Experimental; 
using UnityEngine;

public class LoadMenus_Manager_ZacB : MonoBehaviour
{
    public bool isPressedStartGame;
    public bool submit; 
    [SerializeField] public MainMenu_InteractiveControls_ZacB mM;
    [SerializeField] public PlayerInput controls; 

    private void OnEnable()
    {
        mM.inputAction.Enable();
        mM.playerInput.actions.FindActionMap("PlayerControl");
        mM.playerInput.actions.FindAction("Submit");

        mM.inputAction.performed += OnSubmit;
    }

    private void Submit_performed(InputAction.CallbackContext obj) 
    {
        Debug.Log("Submit Pressed"); 
    }

    private void OnDisable()
    {
        mM.inputAction.Disable();
        mM.inputAction.performed -= OnSubmit;
    }

    public void OnClickStartGame()
    {
        isPressedStartGame = true; 
        if(isPressedStartGame == true && mM.startGame == true || isPressedStartGame == true)
        {
            Debug.Log("Start Game");
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
            return;
        }
    }

    private void LateUpdate()
    {
        if(controls == null)
        {
            return; 
        }
    }

    public void OnSubmit(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            submit = true;
            if (submit == true && mM.startGame == true && controls != null)
            {
                if (mM.playerInput.actions.FindAction("Submit").Equals("Submit[Any]"))                 
                {
                    Debug.Log("Starting Game");
                    SceneManager.LoadSceneAsync(1, LoadSceneMode.Single); // 0, loads menu, 1 loads game scene 
                }

                if (Keyboard.current.enterKey.isPressed && mM.startGame == true)
                {
                    Debug.Log("Doing something");
                    SceneManager.LoadSceneAsync(1, LoadSceneMode.Single); // 0 loads menu, 1 loads game scene 
                }
            }
        }
        else if(controls == null || !context.performed)
        {
            return; 
        }
    }

    public void OnApplicationQuit() // Quit application function call 
    {
        Application.Quit(); 
    }
}