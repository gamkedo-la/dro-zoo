using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem; 
using UnityEngine;

public class InputDectector_ZacB : MonoBehaviour
{
    public InputActionAsset actions;
    PlayerInput playerControl; // get player control asset input 
    public static ControlDevice controlDevice;

    private void Start()
    {
        playerControl = GetComponent<PlayerInput>(); 
        playerControl.onControlsChanged += OnControlsChanged; // subscribe to Control Devices 
    }

    public enum ControlDevice 
    {
        Keyboard, 
        Gamepad 
    }

    private void OnControlsChanged(PlayerInput playerInput)
    {
        if(playerInput.currentControlScheme == "Keyboard")
        {
            if(controlDevice != ControlDevice.Keyboard)
            {
                controlDevice = ControlDevice.Keyboard;
            }
        }
        else
        {
            if (playerInput.currentControlScheme == "Gamepad")
            {
                if (controlDevice != ControlDevice.Gamepad)
                {
                    controlDevice = ControlDevice.Gamepad;
                }
            }
        }
    }

    private void Update()
    {
        if(actions.FindControlScheme("Keyboard").HasValue)
        {
            Debug.Log("Keyboard Input Detected"); 
        }
        else
        {
            if(actions.FindControlScheme("Gamepad").HasValue)
            {
                Debug.Log("Gamepad Input Detected");
            }
        }
    }
}