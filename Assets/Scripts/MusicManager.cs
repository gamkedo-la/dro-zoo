using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private List<AudioSource> _layers;
    private float _intensity = 0.0f;
    private float _max_intensity = 1.0f;
    private float _min_intensity = 0.0f;

    private float _current_playback_master_time;

    [SerializeField] public float fadeRate;
    [SerializeField] public float startIntensity;  // to support 0 or more layers already playing at start

    public float intensity
    {
        get => _intensity;
        set
        {
            _intensity = value;
            if (_intensity < _min_intensity )
                _intensity = _min_intensity;

            if (_intensity > _max_intensity)
                _intensity = _max_intensity;

            // at each change in intensity, run back through the layers and play the ones matching the newest intensity. 
            PlayAllLayers();
        }
    }
    
    void Start()
    {
        _layers = new List<AudioSource>(GetComponentsInChildren<AudioSource>());
        if (startIntensity < _min_intensity)
        {
            startIntensity = _min_intensity;
        }

        _intensity = startIntensity;
        
        // on start, set all music layers to 0 volume so we can fade them in
        foreach (AudioSource layer in _layers)
        {
            layer.volume = 0.0f;
        }
        PlayAllLayers();
    }

    // Play all the layers, but only 
    public void PlayAllLayers()
    {
        // TODO: add crossfade between this group of layers and another group of layers if this music manager has different tracks than the ones currently being played
        
        // if any layer is playing, get its player time to sync all the others
        foreach (AudioSource layer in _layers)
        {
            if (layer.isPlaying == true)
            {
                _current_playback_master_time = layer.time;
                break; // just need the timing from any of the current playing layers
            }
        }
    
        foreach (AudioSource layer in _layers)
        {
            
            string _pattern = @"\-(?<intensity>\d+\.\d+)$";  // Matches:  "any string-name-you want-0.1.wav" 
            string _pattern2 = @"^(?<intensity>\d+\.\d+)_"; // matches: "0.10_any name-you_want_to-call-version2.wav"
            
            Match _layer_intensity_split = Regex.Match(layer.clip.name, _pattern);
            if (! Regex.IsMatch(layer.clip.name, _pattern))
            {
                _layer_intensity_split = Regex.Match(layer.clip.name, _pattern2);
            }

            float _my_layer_float = float.Parse(_layer_intensity_split.Groups["intensity"].Value); 
            if (_my_layer_float <= _intensity)
            {
                if (layer.isPlaying == false)
                {
                    // TODO: put time set and loop bool set somewhere else?
                    layer.time = _current_playback_master_time;
                    
                    StartCoroutine(fadeMusicLayer(layer, fadeRate, 1.0f));
                } 
            }
            else
            {
                if (layer.isPlaying == true)
                {
                    StartCoroutine(fadeMusicLayer(layer, fadeRate, 0.0f));
                }
            }
        }
    }

    // based on the time allowed, fade from 0 to 1 for the layer if fadeIn is true
    private IEnumerator fadeMusicLayer(AudioSource layer, float fadeRate, float targetVolume)
    {
        // TODO: detect direction and DRY up this if and WHILE
        
        // we are quieter than the targetVolume, fade up
        if (layer.volume < targetVolume)
        {
            layer.loop = true;
            layer.Play();
            while (layer.volume  < targetVolume)
            {
                layer.volume = Mathf.Clamp01(layer.volume + (fadeRate * Time.deltaTime));
                yield return new WaitForEndOfFrame();
            }
        } 
        // we are louder than targetVolume, fade down
        else if (layer.volume > targetVolume)
        {
            while (layer.volume > targetVolume)
            {
                layer.volume = Mathf.Clamp01(layer.volume - (fadeRate * Time.deltaTime));
                yield return new WaitForEndOfFrame();
            }
            layer.Stop();
        }
    }

    // over the next timeToFade seconds, fade out everything back to minimum intensity
    public void FadeToStartIntensityAfterTime(float timeUntilFade)
    {
        // Debug.Log($"will fade audio in {timeUntilFade} seconds");
        StartCoroutine(_FadeToMinOverTimeCoRoutine(timeUntilFade));
    }
    private IEnumerator _FadeToMinOverTimeCoRoutine(float timeUntilFade)
    {
        // wait timeToFade, then set the _intensity back to startIntensity
        yield return new WaitForSeconds(timeUntilFade);
        // Debug.Log($"Set audio back to {startIntensity}");
        intensity = startIntensity;  // NOTE: this re-runs the PlayAllLayers at each set if we use the public setter 
    }

}
