using System;
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

    private MusicManager _musicManager;

    private void Awake()
    {
        _musicManager = (MusicManager)FindObjectOfType(typeof(MusicManager));
    }

    void Update()
    {
         if (connected){ 
             transform.position = new Vector3(player.position.x  ,player.position.y + yoffset , player.position.z );
         }
    }

    private void OnTriggerEnter(Collider other)
    {
        // if we found the _musicManager on awake, and this is the first time we are coming to this trigger,
        // tell the music manager that a good thing just happened + 0.01f
        if (_musicManager && !connected)
        {
            _musicManager.intensity += 0.01f;
            // Debug.Log($"music intensity is now {_musicManager.intensity}");
        }
        connected = true;
    }

}
