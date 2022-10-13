using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class StatSystem
{
    [SerializeField]
    private int baseValue;

    public int getValue()
    {
        return baseValue;
    }
}