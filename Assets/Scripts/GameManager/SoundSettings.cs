using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    public Slider VolumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SetVolume(float value)
    {
        AudioListener.volume = value;
        PlayerPrefs.SetFloat(CONSTANT.PP_VOLUME, value);
    }
    void LoadVolume()
    {
        VolumeSlider.value = PlayerPrefs.GetFloat(CONSTANT.PP_VOLUME);
    }
}
