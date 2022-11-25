using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MenuUIManager : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject SettingsMenu;
    public SettingAudio settingAudio;
    public GameObject AudioMenu;
    public GameObject GraphicMenu;
    public GameObject _MainCanvas;
    public GameObject _HowTopPlayPanel;


    public void OnClickPlayGame(string sceneName)
    {
        LevelManager.Instance.LoaderScene(sceneName);
        Time.timeScale = 1f;
    }
        
    public void OnClickExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void OnClickSettingButton()
    {
        MainMenu.SetActive(false);
        SettingsMenu.SetActive(true);
    }
    public void OnClickSettingBackButton()
    {
        MainMenu.SetActive(true);
        SettingsMenu.SetActive(false);
        settingAudio.OnApplySetting();
    }
    public void OnClickAudioButton()
    {
        AudioMenu.SetActive(true);
        GraphicMenu.SetActive(false);
    }
    public void OnClickGraphicButton()
    {
        AudioMenu.SetActive(false);
        GraphicMenu.SetActive(true);
    }
    public void OnClickHTPlayButton()
    {
        MainMenu.SetActive(false);
        _HowTopPlayPanel.SetActive(true);
    }
    public void OnClickBackHTPlayButton()
    {
        MainMenu.SetActive(true);
        _HowTopPlayPanel.SetActive(false);
    }
}
