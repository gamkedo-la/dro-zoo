using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{

    public AudioMixer audioMixer;

    public void SetMasterVolume(Slider volume){
        audioMixer.SetFloat("masterVolume", volume.value / 100f * -80f);
    }

    public void SetSFXVolume(Slider volume){
        audioMixer.SetFloat("sfxVolume", volume.value / 100f * -80f);
    }

    public void SetMusicVolume(Slider volume){
        audioMixer.SetFloat("musicVolume", volume.value / 100f * -80f);
    }


}
