using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyStat : BaseStatSystem
{
    public Animator animator;
    
    XPstat GetXPstat;
    private bool die = false;
    

    

    private void Start()
    {
        GetXPstat = playerManager.instance.Player.GetComponent<XPstat>();
        caculatorStats(level);
    }

    private void Update()
    {
        
    }

    public override void Die()
    {
        if (!die)
        {
            die = true;
            animator.SetTrigger("die");
            GetXPstat.GainXPFlatRate(GetXPstat.CaculatorXPgain(level));
            Destroy(gameObject, 5f);

        }
        base.Die();
    }
}