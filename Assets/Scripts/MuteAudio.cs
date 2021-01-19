using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MuteAudio : MonoBehaviour
{
    public InputActionAsset playerControls;
    public AudioClip muteButtonAudio;

    private bool isMuted = false;
    private float waitForSFX = 0f;
    private float originalVolume;
    private InputAction mute;

    private void OnEnable() {
        if(playerControls){
        mute = playerControls.FindActionMap("PlayerControl").FindAction("PlayerAudio");
        mute.performed += OnMute;
        mute.Enable();
        } else {
            Debug.LogWarning("Mute Audio script in " + gameObject.name + " could not find a InputActionAsset");
        }
    }

    private void OnDisable() {
        mute.Disable();
    }

    private void OnMute(InputAction.CallbackContext context){
        HandleMute();
    }

    public void HandleMute()
    {
        //mutes all audio by lowering Audio Listener's volume to 0
        PlayButtonAudio();
        if(!muteButtonAudio) {
            waitForSFX = 0f;
        } else {
            waitForSFX = muteButtonAudio.length;
        }

        Invoke("ToggleMute", waitForSFX);
                
    }

    private void PlayButtonAudio(){
        if(!muteButtonAudio) {
            return;
        }

        AudioSource.PlayClipAtPoint(muteButtonAudio, Camera.main.transform.position);
    }

    private void ToggleMute()
    {
        isMuted = !isMuted;
        if (isMuted) {
            originalVolume = AudioListener.volume; //if we are muting, store original value
            AudioListener.volume = 0;
        } else {
            AudioListener.volume = originalVolume;
            PlayButtonAudio();
        }
    }

}
