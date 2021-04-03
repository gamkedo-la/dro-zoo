using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Followplayer : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private float yoffset;
    private bool connected;

    void Update()
    {
            if (connected){
         transform.position = new Vector3(player.position.x  ,player.position.y + yoffset , player.position.z );
            }
    }

     private void OnTriggerEnter(Collider other)
    {
        connected = true;
    }

}
