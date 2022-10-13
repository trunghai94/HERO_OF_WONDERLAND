using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : BaseStatSystem
{
    
        
    
    public override void Die()
    {
        base.Die();


        Destroy(gameObject);
    }
}