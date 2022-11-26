using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyStat : BaseStatSystem
{
    public Animator animator;
    
    XPstat GetXPstat;
    private bool die = false;
    private bool dead = false;
    public Image HP;

    private void Start()
    {
        
        caculatorStats(level);
        
    }

    private void Update()
    {
        if(GetXPstat==null) GetXPstat = playerManager.instance.Player.GetComponent<XPstat>();
        HP.fillAmount = currentHeath / maxHeath;
        if (die && !dead)
        {
            animator.SetTrigger("die");
            GetXPstat.GainXPFlatRate(GetXPstat.CaculatorXPgain(level));
            dead = true;
            
            Destroy(gameObject, 5f);
        }
    }

    public override void Die()
    {
        die=true;
        base.Die();
    }
}