using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SettingsGraphic : MonoBehaviour
{
    public TMP_Dropdown qualityIndex;
    public TMP_Dropdown resolutionDprodown;
    private int indexDD;
    Resolution[] resolutions;

    // Start is called before the first frame update
    void Start()
    {
        indexDD = PlayerPrefs.GetInt(CONSTANT.PP_QUALITY);
        qualityIndex.value = indexDD;
        resolutions = Screen.resolutions;
        resolutionDprodown.ClearOptions();
        List<string> opptions = new List<string>();
        int IndexResolution = 0;
        for(int i=0; i<resolutions.Length; i++)
        {
            string opption = resolutions[i].width + "x" + resolutions[i].height;
            opptions.Add(opption);
            if (resolutions[i].width==Screen.currentResolution.width&& resolutions[i].height == Screen.currentResolution.height)
            {
                IndexResolution = i;
            }
        }
        resolutionDprodown.AddOptions(opptions);
        resolutionDprodown.value = IndexResolution;
        resolutionDprodown.RefreshShownValue();
    }

   public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);//chinh do hoa trong game
        PlayerPrefs.SetInt(CONSTANT.PP_QUALITY, qualityIndex);
    }
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    public void setResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
