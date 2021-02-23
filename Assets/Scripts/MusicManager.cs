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
    
    
    // Start is called before the first frame update
    void Start()
    {
        _layers = new List<AudioSource>(GetComponentsInChildren<AudioSource>());
        
        PlayAllLayers();
    }

    public void PlayAllLayers()
    {
        // TODO: add crossfade between this group of layers and another group of layers if this music manager has different tracks than the ones currently being played
        foreach (AudioSource layer in _layers)
        {
            if (layer.isPlaying == true)
            {
                _current_playback_master_time = layer.time;
            }
        }
    
        foreach (AudioSource layer in _layers)
        {
            string _pattern = @"\-(?<intensity>\d+\.\d+)$";
            var _layer_intensity_split = Regex.Match(layer.clip.name, _pattern);
            
            float _my_layer_float = float.Parse(_layer_intensity_split.Groups["intensity"].Value); 
            if (_my_layer_float <= _intensity)
            {
                if (layer.isPlaying == false)
                {
                    // TODO:  Fade IN volume instead of a hard 1.0f jump
                    layer.volume = 1.0f;
                    layer.time = _current_playback_master_time;
                    layer.loop = true;
                    layer.Play();    
                } 
            }
            else
            {
                if (layer.isPlaying == true)
                {
                    // TODO:  Fade OUT volume instead of a hard 0.0f jump
                    layer.volume = 0.0f;
                    layer.loop = false;
                    layer.Stop();
                }
            }
        }
    }
    
    
}
