using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using System;

public class GameManager : SingletonMonoBehaviour<GameManager>
{ 
    // Start is called before the first frame update
    void Start()
    {
        SetStarQuality();
        SetStartEffectVolume();
        SetStartVolume();
    }
    public void EndGame()
    {
        Time.timeScale = 0f;
    }
    public void ResetState()
    {
        Time.timeScale = 1f;
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
    }
    public void OnClickStartGame()
    {
        
    }
    public void OnClickExitGame()
    {

    }
    private void SetStartVolume()
    {
        if (!PlayerPrefs.HasKey(CONSTANT.PP_VOLUME))
        {
            PlayerPrefs.SetFloat(CONSTANT.PP_VOLUME, CONSTANT.DEFAULT_VOLUME);
            AudioListener.volume = CONSTANT.DEFAULT_VOLUME;
        }
        else
        {
            float volume = PlayerPrefs.GetFloat(CONSTANT.PP_VOLUME);
            AudioListener.volume = volume;
        }
    }
    private void SetStartEffectVolume()
    {
        if (!PlayerPrefs.HasKey(CONSTANT.PP_EFVOLUME))
        {
            PlayerPrefs.SetFloat(CONSTANT.PP_EFVOLUME, CONSTANT.DEFAULT_EFVOLUME);
            AudioListener.volume = CONSTANT.DEFAULT_EFVOLUME;
        }
        else
        {
            float volume = PlayerPrefs.GetFloat(CONSTANT.PP_EFVOLUME);
            AudioListener.volume = volume;
        }
    }
    private void SetStarQuality()
    {
        if (!PlayerPrefs.HasKey(CONSTANT.PP_QUALITY))
        {
            PlayerPrefs.SetFloat(CONSTANT.PP_QUALITY, CONSTANT.DEFAULT_QUALITY);
            QualitySettings.SetQualityLevel(CONSTANT.DEFAULT_QUALITY);
        }
        else
        {
            int QualityIndex = PlayerPrefs.GetInt(CONSTANT.PP_QUALITY);
            QualitySettings.SetQualityLevel(QualityIndex);
        }
    }
}
