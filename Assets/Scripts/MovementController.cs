using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class MovementController : MonoBehaviour
{
    public Rigidbody dronerb;
    public float speed;
    public float spin;
    public Transform modelspin;

    Vector3 forceNow = Vector3.zero;
    Vector3 spinNow = Vector3.zero;

    private void FixedUpdate() {
        dronerb.AddForce(forceNow, ForceMode.Force);
        dronerb.AddTorque(spinNow, ForceMode.Force);
    }

    private void OnPlayerMovement(InputValue value)
    {
        var position = gameObject.transform.position;
        Vector2 inputValue = value.Get<Vector2>();

        forceNow = new Vector3 ( inputValue.x * speed,
                        forceNow.y, // preserve as it decays
                        inputValue.y * speed) ;
    } 

    private void OnPlayerHeight(InputValue value)
    {
        var position = gameObject.transform.position;
        Vector2 inputValue = value.Get<Vector2>();

        forceNow = new Vector3 ( forceNow.x,
                                inputValue.y * speed, // only changing vertical
                                forceNow.z) ;
        spinNow = new Vector3 ( 0f, inputValue.x, 0f) * spin ;
    } 
}