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

    private void OnPlayerMovement(InputValue value)
    {
        var position = gameObject.transform.position;
        Vector2 inputValue = value.Get<Vector2>();

        /* gameObject.transform.position = new Vector3(
            position.x + (inputValue.x/10),
            position.y,
            position.z + (inputValue.y/10)

        ); */

        Vector3 apply = Vector3.zero;
        apply = new Vector3 ( inputValue.x, 0f, inputValue.y) * speed ;
        dronerb.AddForce( apply ,ForceMode.Force);
    } 

    private void OnPlayerHeight(InputValue value)
    {
        var position = gameObject.transform.position;
        Vector2 inputValue = value.Get<Vector2>();

        /* gameObject.transform.position = new Vector3(
            position.x,
            position.y + (inputValue.y/10),
            position.z

        ); */

        Vector3 apply = Vector3.zero;
        apply = new Vector3 ( 0f, inputValue.y, 0f) * speed ;
        dronerb.AddForce( apply ,ForceMode.Force);

        Vector3 rotate = Vector3.zero;
        rotate = new Vector3 ( 0f, inputValue.x, 0f) * spin ;
        dronerb.AddTorque( rotate ,ForceMode.Force);
    } 
}