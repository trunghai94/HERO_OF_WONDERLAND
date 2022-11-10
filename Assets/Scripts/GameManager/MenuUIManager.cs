using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUIManager : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject SettingsMenu;
    public SettingAudio settingAudio;
    
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
   
}
