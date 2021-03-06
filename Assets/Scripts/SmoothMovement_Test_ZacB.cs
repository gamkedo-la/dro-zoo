using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Haptics;
using UnityEngine;
using System;

public class SmoothMovement_Test_ZacB : MonoBehaviour
{
    InputAction actions; 

    /* Test Smooth Movement */ // ZacB 
    [SerializeField] private Rigidbody droneRB;
    public float droneSpeed;
    public float droneSpin; 
    Vector2 move;

    [SerializeField] private InputActionAsset droneControls;
    public InputAction inputAction;
    InputAction.CallbackContext context;

    internal void OnPlayerSmoothMove()
    {
        throw new NotImplementedException();
    }

    internal void OnPlayerHeightSmooth()
    {
        throw new NotImplementedException();
    }

    private void Awake()
    {
        var actionMap = droneControls.FindActionMap("PlayerControl");
        inputAction.performed += SmoothMovement_Test_ZacB_actionTriggered;
        inputAction.canceled += SmoothMovement_Test_ZacB_actionTriggered;
        inputAction.Enable(); 

        actions = new InputAction();
        actions.performed += context => OnSmoothMove();

        inputAction = droneControls.FindAction("PlayerMovement"); // get test action map Action  
    }

    private void OnEnable()
    {
        droneControls.Enable();
    }

    private void OnDisable()
    {
        droneControls.Disable(); 
    }

    private void Update()
    {
        SmoothMovement_Test_ZacB_actionTriggered(context);
    }

    private void SmoothMovement_Test_ZacB_actionTriggered(InputAction.CallbackContext context)
    {
       if(context.performed || Gamepad.current.IsPressed() || Keyboard.current.IsPressed())
        {
            OnSmoothMove(); 
        }

        if(Gamepad.current.IsPressed())
        {
            Debug.Log("Is GamePad");
        }
        else if(Keyboard.current.IsPressed())
        {
            Debug.Log("Is KeyBoard");
        }
    }

    public virtual void OnPlayerSmoothMove(InputValue value)
    {
        if(value.isPressed)
        {
            Vector3 pos = transform.position;
            Vector2 inputValue = value.Get<Vector2>();

            Vector3 normal = Vector3.zero;
            normal = new Vector3(inputValue.x, 0, inputValue.y) * droneSpeed * Time.deltaTime;
            droneRB.AddForce(normal, ForceMode.VelocityChange);
        }    
    }

    public virtual void OnPlayerHeightSmooth(InputValue value)
    {
        if(value.isPressed)
        {
            Vector3 pos = transform.position;
            Vector2 inputValue = value.Get<Vector2>();

            Vector3 normal = Vector3.zero;
            normal = new Vector3(inputValue.x, 0, inputValue.y) * droneSpeed * Time.deltaTime;
            droneRB.AddForce(normal, ForceMode.VelocityChange);

            Vector3 rot = Vector3.zero;
            normal = new Vector3(inputValue.x, 0, inputValue.y) * droneSpin * Time.deltaTime;
            droneRB.AddForce(rot, ForceMode.VelocityChange);
        } 
    }

    public virtual void OnSmoothMove()
    {
        OnSmoothMovemnt(); 
    }

    public virtual void OnSmoothMovemnt()
    {
        Vector3 pos = transform.position;
        Vector3 lastPos = Vector3.zero;

        //if (droneRB.velocity.magnitude > 0)
        //{
        //    lastPos = new Vector3(0, transform.position.y, 0) * droneSpeed * Time.deltaTime;
        //    transform.position = Vector3.Lerp(pos, lastPos, 0.1f * droneSpeed * Time.deltaTime);
        //    return;
        //}
        //else if (droneRB.velocity.magnitude < 0)
        //{
        //    lastPos = new Vector3(0, -transform.position.y, 0) * droneSpeed * Time.deltaTime;
        //    transform.position = Vector3.Lerp(lastPos, pos, 0.1f * droneSpeed * Time.deltaTime);
        //    return;
        //}

        //if (droneRB.velocity.magnitude > -1)
        //{
        //    lastPos = new Vector3(transform.position.x, 0, 0) * droneSpeed * Time.deltaTime;
        //    transform.position = Vector3.Lerp(pos, lastPos, 0.1f * droneSpeed * Time.deltaTime);
        //    return;
        //}
        //else if (droneRB.velocity.magnitude < 1)
        //{
        //    lastPos = new Vector3(-transform.position.x, 0, 0) * droneSpeed * Time.deltaTime;
        //    transform.position = Vector3.Lerp(lastPos, pos, 0.1f * droneSpeed * Time.deltaTime);
        //    return;
        //}

        if (inputAction.ReadValue<Vector2>().x > 0)
        {
            droneRB.AddForce(Vector3.forward * droneSpeed * Time.deltaTime);
        }
        else if (inputAction.ReadValue<Vector2>().x < 0)
        {
            droneRB.AddForce(Vector3.back * droneSpeed * Time.deltaTime);
        }
        if (inputAction.ReadValue<Vector2>().x > 0.1f)
        {
            droneRB.AddForce(Vector3.right * droneSpeed * Time.deltaTime); 
        }
        else if (inputAction.ReadValue<Vector2>().x < -0.1f)
        {
            droneRB.AddForce(Vector3.left * droneSpeed * Time.deltaTime);
        }

        if (inputAction.ReadValue<Vector2>().y > 0)
        {
            droneRB.AddForce(Vector3.up * droneSpeed * Time.deltaTime);
        }
        else if (inputAction.ReadValue<Vector2>().y < 0)
        {
            droneRB.AddForce(Vector3.down * droneSpeed * Time.deltaTime);
        }
        if (inputAction.ReadValue<Vector2>().y > 0.1f)
        {
            droneRB.AddForce(Vector3.right * droneSpeed * Time.deltaTime);
        }
        else if (inputAction.ReadValue<Vector2>().y > -0.1f)
        {
            droneRB.AddForce(Vector3.left * droneSpeed * Time.deltaTime);
        }
        else
        {
            Vector3.Normalize(transform.position); 
        }

        Debug.Log(inputAction.ReadValue<Vector2>());
    }
    /* End Test Movement */
}