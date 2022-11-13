using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InHouseSDK : MonoBehaviour
{
    [MenuItem("InHouseSDK/Clear PlayerPref")]
    static void ClearPlayerPref()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Delete All");
    }
}
