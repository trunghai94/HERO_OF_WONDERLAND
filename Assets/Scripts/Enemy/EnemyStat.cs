using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyStat : BaseStatSystem
{
    public Animator animator;
    public int level;

    private void Update()
    {
        
        
    }


    public override void Die()
    {
        base.Die();
        animator.SetTrigger("die");
        
        Destroy(gameObject,5f);
    }
}