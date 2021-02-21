using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System;

public class OptionsMenuHandler : MonoBehaviour
{

    [Tooltip("Panel object which is also parent for options menu content")]
    [SerializeField] GameObject menuPanel;
    [Header("Player Input Action Asset:")]
    public InputActionAsset playerControls;


    public bool enablePauseMenu;

    private InputAction pauseInput;
    private bool pauseToggle = false;
    private float origTimeScale;


    private void OnEnable() {
        pauseInput = playerControls.FindActionMap("PlayerControl").FindAction("PauseGame");
        pauseInput.started += OnPauseGame;
        pauseInput.Enable();
    }

    private void OnDisable() {
        pauseInput.Disable();
    }
    
    private void OnPauseGame(InputAction.CallbackContext context){
        pauseToggle = !pauseToggle;
        TogglePauseMenu(pauseToggle);
    }
    
    void Start()
    {
        //if this is used as a singleton and set in start menu, the following prevents duplicates from any OptionsMenuHandlers in scenes
        OptionsMenuHandler[] menuHandlers = FindObjectsOfType<OptionsMenuHandler>();
        if(menuHandlers.Length > 1){
            Debug.Log("Found multiple OptionsMenuHandlers in scene. Deleting OptionsMenuHandler object called " + this.gameObject.name);
            Destroy(this.gameObject);
        }
        menuPanel.SetActive(false); //disable menu when scene is started
         //set original timescale
        origTimeScale = Time.timeScale;
    }

    public void TogglePauseMenu(bool t)
    {
        menuPanel.SetActive(t);
        //set timescale
        if(pauseToggle){
            Time.timeScale = 0f;
        } else {
            Time.timeScale = origTimeScale;
        }
    }

    public void LeaveOptionsMenu(){
        //call this function when closing menu from UI button in Options menu
        pauseToggle = false;
        TogglePauseMenu(pauseToggle);
    }

    public void OpenOptionsMenu(){
        //call this function when opening menu from a UI button
        pauseToggle = true;
        TogglePauseMenu(pauseToggle);
    }
}
