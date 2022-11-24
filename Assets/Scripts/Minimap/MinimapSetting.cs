using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapSetting : MonoBehaviour
{
    public static MinimapSetting instance;
    public Transform targetFollow;
    public bool rotateWithTheTarget = true;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        targetFollow = playerManager.instance.transform;
    }
}
