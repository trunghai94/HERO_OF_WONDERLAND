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
    AudioManager audioManager;
    private float bgValue, curValue;
    private float efValue, curEfValue;
    // Start is called before the first frame update
    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        LoadBGVolume();
        LoadEffectVolume();
    }

    public void SetBGMUsicVolume(float value)
    {
        foreach (var music in audioManager.backgroundMusic)
        {
            music.source.volume = value;
        }
        PlayerPrefs.SetFloat(CONSTANT.PP_VOLUME, value);

    }
    public void SetEffVolume(float value)
    {
        foreach (var effect in audioManager.soundEffect)
        {
            effect.source.volume = value;
        }
        PlayerPrefs.SetFloat(CONSTANT.PP_EFVOLUME, value);
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

  
}
