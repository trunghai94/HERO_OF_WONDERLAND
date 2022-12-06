using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class SettingAudio : MonoBehaviour
{
    public Slider BGVolumeSlider;
    public Slider EffectVolumeSlider;
    public AudioManager AudioSource;
    private float bgValue, curValue;
    private float efValue, curEfValue;
    // Start is called before the first frame update
    void Start()
    {
        LoadBGVolume();
        LoadEffectVolume();
     
    }
   public void SetBGMUsicVolume(float value)
    {
        foreach (var music in AudioSource.backgroundMusic)
        {
            music.source.volume = value;
        }
        curValue = value;
    }
    public void SetEffVolume(float value)
    {
        foreach(var effect in AudioSource.soundEffect)
        {
            effect.source.volume = value;
        }
        curEfValue = value;
    }
    void LoadBGVolume()
    {
        bgValue = PlayerPrefs.GetFloat(CONSTANT.PP_VOLUME, CONSTANT.DEFAULT_VOLUME);
        Debug.Log(bgValue);
        BGVolumeSlider.value = bgValue;
    }
   
    void LoadEffectVolume()
    {
        efValue = PlayerPrefs.GetFloat(CONSTANT.PP_EFVOLUME, CONSTANT.DEFAULT_EFVOLUME);
        EffectVolumeSlider.value = efValue;
    }

    public void OnApplySetting()
    {
        if(curValue != bgValue)
        {
            AudioManager.Instance?.SetBGMVolume(curValue);
        }
        if (curEfValue != efValue)
        {
            AudioManager.Instance?.SetEffectVolume(efValue);
        }
    }
    
}
