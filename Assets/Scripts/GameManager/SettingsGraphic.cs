using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SettingsGraphic : MonoBehaviour
{
    public TMP_Dropdown qualityIndex;
    private int indexDD;
    // Start is called before the first frame update
    void Start()
    {
        indexDD = PlayerPrefs.GetInt(CONSTANT.PP_QUALITY);
        qualityIndex.value = indexDD;
        
    }

   public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);//chinh do hoa trong game
        PlayerPrefs.SetInt(CONSTANT.PP_QUALITY, qualityIndex);
    }    
}
