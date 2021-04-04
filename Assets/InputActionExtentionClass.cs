using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public static class InputActionExtension 
{
    public static bool IsPressed(this InputAction inputAction)
    {
        return inputAction.ReadValue<float>() > 0; 
    }

    public static bool WasPressedThisFrame(this InputAction inputAction)
    {
        return inputAction.ReadValue<float>() > 0 && inputAction.triggered;
    }

    public static bool WasReleasedThisFrame(this InputAction inputAction)
    {
        return inputAction.ReadValue<float>() == 0 && inputAction.triggered; 
    }
}