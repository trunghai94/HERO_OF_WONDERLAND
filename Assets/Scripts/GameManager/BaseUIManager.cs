using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUIManager : MonoBehaviour
{
    public void OnUIClick()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlayEffect("Click");
        }
    }
    public void OnUIHover()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlayEffect("Hover");
        }
    }

}
