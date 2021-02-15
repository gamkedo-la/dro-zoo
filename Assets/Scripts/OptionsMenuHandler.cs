using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System;

public class OptionsMenuHandler : MonoBehaviour
{

    [SerializeField] GameObject menuPanel;

    public bool enablePauseMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        menuPanel.SetActive(false);
    }

    private void HandlePause(){
        //TODO call this from OnPause instead of direct input and update call
        bool pauseInput = Keyboard.current.pKey.wasPressedThisFrame;
        if(pauseInput){
            enablePauseMenu = !enablePauseMenu;
            TogglePauseMenu(enablePauseMenu);
        }

        
    }

    private void TogglePauseMenu(bool t)
    {
        menuPanel.SetActive(t);
    }



    // Update is called once per frame
    void Update()
    {
        HandlePause();
        

    }

    public void LeaveOptionsMenu(){

    }
}
