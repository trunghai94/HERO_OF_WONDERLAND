using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : BaseStatSystem
{
    public Image Hp;
    private Animator animator;
    private bool die = false;
    private bool dead = false;

    private void Start()
    {
        caculatorStats(level);
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        Hp.fillAmount = currentHeath / maxHeath;
        if (die && !dead)
        {
            animator.SetTrigger("Died");
            dead = true;
            //Destroy(gameObject, 5f);
        }
    }

    public override void Die()
    {
        die = true;
        base.Die();
    }
}
