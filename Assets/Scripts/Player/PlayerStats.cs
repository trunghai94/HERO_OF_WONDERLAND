using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : BaseStatSystem
{
    public Slider Hp;

    private void Start()
    {
        Hp.maxValue = maxHeath;
        
    }
    private void Update()
    {
        Hp.value = currentHeath;
    }



}
