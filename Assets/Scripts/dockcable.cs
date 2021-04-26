using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dockcable : MonoBehaviour
{
    
    [SerializeField]
    private GameObject endcable;
    [SerializeField]
    private GameObject plant1;
    [SerializeField]
    private GameObject plant2;

    [SerializeField]
    private AudioSource cableplugin;

    private MusicManager _musicManager;

    // temp win state boolean 
    public bool isGrown; 
    
    private void Awake()
    {
        _musicManager = (MusicManager)FindObjectOfType(typeof(MusicManager));
    }
       
    private void OnTriggerEnter(Collider other)
    {
        endcable.GetComponent<Followplayer>().enabled = false;
        plant1.GetComponent<Animator>().SetTrigger("Grow");
        plant2.GetComponent<Animator>().SetTrigger("Grow");
        
        cableplugin.Play();
        isGrown = true; 

        if (_musicManager)
        {
            _musicManager.intensity += 0.05f;
            // Debug.Log($"music intensity is now {_musicManager.intensity}");
            _musicManager.FadeToStartIntensityAfterTime(30.00f);
        }
    }
}
