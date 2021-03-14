using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem; 
using UnityEngine;

public class InputDectector_ZacB : MonoBehaviour
{
    public InputActionAsset actions;
    PlayerInput playerControl; // get player control asset input 
    public static ControlDevice controlDevice;
    public static int control;
    public bool keyboard;
    public bool controller; 

    private void Start()
    {
        playerControl = GetComponent<PlayerInput>(); 
        playerControl.onControlsChanged += OnControlsChanged; // subscribe to Control Devices 
        control = 0; 
    }

    public enum ControlDevice 
    {
        Keyboard, 
        Gamepad 
    }

    private void OnControlsChanged(PlayerInput playerInput)
    {
        if(playerInput.currentControlScheme == "Keyboard" && control == 0)
        {
            controller = false;
            keyboard = true; 
            if(controlDevice != ControlDevice.Keyboard)
            {
                controlDevice = ControlDevice.Keyboard;
            }
        }
        else if(playerInput.SwitchCurrentControlScheme() && playerInput.currentControlScheme == "Gamepad")
        {
            control = 1; 
            if (playerInput.currentControlScheme == "Gamepad" && control == 1)
            {
                controller = true;
                keyboard = false; 
                if (controlDevice != ControlDevice.Gamepad)
                {
                    controlDevice = ControlDevice.Gamepad;
                }
            }
        }
    }

    private void Update()
    {
        if(actions.controlSchemes.Count >= 0)
        {
            if (actions.FindControlScheme("Keyboard").HasValue)
            {
                control = 0;
                Debug.Log("Keyboard Input Detected");
            }
            else if (actions.controlSchemes.Count < 0)
            {
                if (actions.FindControlScheme("Gamepad").HasValue)
                {
                    control = 1;
                    Debug.Log("Gamepad Input Detected");
                }
            }
            return; 
        }
    }
}