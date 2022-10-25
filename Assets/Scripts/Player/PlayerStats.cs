using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : BaseStatSystem
{
    public Image Hp;
    
    private void Start()
    {
        
        
        caculatorStats(level);
    }
    private void Update()
    {
        
        Hp.fillAmount = currentHeath / maxHeath;
        
    }

    


}
