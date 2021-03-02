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

    /* Test Smooth Movement */ // ZacB 

    public virtual void OnSmoothMovemnt()
    {
        Vector3 pos = transform.position;
        Vector3 lastPos = Vector3.zero; 
        if(dronerb.velocity.magnitude > 0)
        {
            lastPos = new Vector3(0, transform.position.y, 0) * speed * Time.deltaTime;  
            transform.position = Vector3.Lerp(pos, lastPos, 0.1f * speed * Time.deltaTime);
            return; 
        }
        else if (dronerb.velocity.magnitude < 0)
        {
            lastPos = new Vector3(0, -transform.position.y, 0) * speed * Time.deltaTime;
            transform.position = Vector3.Lerp(lastPos, pos, 0.1f * speed * Time.deltaTime);
            return;
        }

        if (dronerb.velocity.magnitude > -1)
        {
            lastPos = new Vector3(transform.position.x, 0, 0) * speed * Time.deltaTime;
            transform.position = Vector3.Lerp(pos, lastPos, 0.1f * speed * Time.deltaTime);
            return;
        }
        else if (dronerb.velocity.magnitude > 1)
        {
            lastPos = new Vector3(-transform.position.x, 0, 0) * speed * Time.deltaTime;
            transform.position = Vector3.Lerp(lastPos, pos, 0.1f * speed * Time.deltaTime);
            return;
        }
    }

    /* End Test Movement */ 
}