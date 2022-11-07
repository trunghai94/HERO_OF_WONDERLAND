using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    public Slider BGVolumeSlider;
    public Slider EffectVolumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        LoadBGVolume();
        LoadEffectVolume();
    }
    public void SetEffectVolume(float value)
    {
        
        PlayerPrefs.SetFloat(CONSTANT.PP_EFVOLUME, value);
        AudioListener.volume = value;
    }
    void LoadEffectVolume()
    {
        EffectVolumeSlider.value = PlayerPrefs.GetFloat(CONSTANT.PP_EFVOLUME); 
    }
    public void SetVolume(float value)
    {
        
        PlayerPrefs.SetFloat(CONSTANT.PP_VOLUME, value);
        AudioListener.volume = value;
    }
    void LoadBGVolume()
    {
        BGVolumeSlider.value = PlayerPrefs.GetFloat(CONSTANT.PP_VOLUME);
    }
}
