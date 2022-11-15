using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUIManager : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject SettingsMenu;
    public SettingAudio settingAudio;
    public GameObject AudioMenu;
    public GameObject GraphicMenu;

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
