using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public AudioMixer masterMixer;
    public Scrollbar slider;

    public void SetMusicVolume()
    {
        masterMixer.SetFloat ("MusicVol", Mathf.Log10 (slider.value) * 20);
    }

    public void SetEffectsVolume()
    {
        masterMixer.SetFloat ("EffectsVol", Mathf.Log10 (slider.value) * 20);
    }

    private void Update()
    {
        SetEffectsVolume();
        SetMusicVolume();

        if(slider.value <= 0.000001f)
        {
            slider.value = 0.000002f;
        }
    }
}
