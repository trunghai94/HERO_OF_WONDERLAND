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
    // Start is called before the first frame update
    void Start()
    {
        LoadBGVolume();
        
        //LoadEffectVolume();
    }
   public void SetBGMUsicVolume(float value)
    {
        curValue = value;
        BGVolumeSlider.value = value;
        AudioListener.volume = value;
    }
    void LoadBGVolume()
    {
        bgValue = PlayerPrefs.GetFloat(CONSTANT.PP_VOLUME, CONSTANT.DEFAULT_VOLUME);
        Debug.Log(bgValue);
        BGVolumeSlider.value = bgValue;
    }
   
    void LoadEffectVolume()
    {
        AudioSource.SetBGMVolume(EffectVolumeSlider.value);
    }

    public void OnApplySetting()
    {
        if(curValue != bgValue)
        {
            AudioManager.Instance?.SetBGMVolume(curValue);
        }
    }
    
}
