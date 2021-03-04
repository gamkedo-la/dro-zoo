using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem.Haptics;

public class SmoothMovement_Test_ZacB : MonoBehaviour
{
    InputAction actions; 

    /* Test Smooth Movement */ // ZacB 
    [SerializeField] private Rigidbody droneRB;
    [SerializeField] private InputActionAsset droneControls; 
    public float droneSpeed;
    Vector2 move;

    private void Awake()
    {
        actions = new InputAction();
        actions.performed += context => OnSmoothMove();

        droneControls = new InputActionAsset();
        droneControls.name = "PlayerMovement"; 
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
        Vector2 moveVar = new Vector2(move.x, move.y) * droneSpeed * Time.deltaTime; 
        transform.Translate(moveVar, Space.World); 
    }

    void OnSmoothMove()
    {
        transform.TransformDirection(Vector3.Lerp(transform.position, droneRB.position, 1) * Time.deltaTime); 
    }

    public virtual void OnSmoothMovemnt()
    {
        Vector3 pos = transform.position;
        Vector3 lastPos = Vector3.zero;
        if (droneRB.velocity.magnitude > 0)
        {
            lastPos = new Vector3(0, transform.position.y, 0) * droneSpeed * Time.deltaTime;
            transform.position = Vector3.Lerp(pos, lastPos, 0.1f * droneSpeed * Time.deltaTime);
            return;
        }
        else if (droneRB.velocity.magnitude < 0)
        {
            lastPos = new Vector3(0, -transform.position.y, 0) * droneSpeed * Time.deltaTime;
            transform.position = Vector3.Lerp(lastPos, pos, 0.1f * droneSpeed * Time.deltaTime);
            return;
        }

        if (droneRB.velocity.magnitude > -1)
        {
            lastPos = new Vector3(transform.position.x, 0, 0) * droneSpeed * Time.deltaTime;
            transform.position = Vector3.Lerp(pos, lastPos, 0.1f * droneSpeed * Time.deltaTime);
            return;
        }
        else if (droneRB.velocity.magnitude > 1)
        {
            lastPos = new Vector3(-transform.position.x, 0, 0) * droneSpeed * Time.deltaTime;
            transform.position = Vector3.Lerp(lastPos, pos, 0.1f * droneSpeed * Time.deltaTime);
            return;
        }
    }
    /* End Test Movement */
}