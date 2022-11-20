using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MenuUIManager : SingletonMonoBehaviour<MenuUIManager>
{
    public GameObject MainMenu;
    public GameObject SettingsMenu;
    public SettingAudio settingAudio;
    public GameObject AudioMenu;
    public GameObject GraphicMenu;
    public SceneLoader sceneloader;



    public void OnClickPlayGame()
    {
        sceneloader.LoadLevel("Map1");
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

}
