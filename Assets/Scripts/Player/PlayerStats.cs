using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : BaseStatSystem
{
    public Image Hp;
    private Animator animator;
    public bool die = false;
    public bool dead = false;
  
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

            MainUIManager.Instance.ShowUILooseGame();
        }
    }

    public override void Die()
    {
        die = true;
        base.Die();
    }
}
