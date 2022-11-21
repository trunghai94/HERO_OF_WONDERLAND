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
    public MainUIManager showLose;
    
    

    private void Start()
    {
        caculatorStats(level);
        animator = GetComponent<Animator>();
        showLose = this.gameObject.GetComponent<MainUIManager>();
    }
    private void Update()
    {
        
        Hp.fillAmount = currentHeath / maxHeath;
        if (die && !dead)
        {
            animator.SetTrigger("Died");
            dead = true;
            //Destroy(gameObject, 5f);
            showLose.ShowUILooseGame();
            
        }
    }

    public override void Die()
    {
        die = true;
        base.Die();
       
    }
}
