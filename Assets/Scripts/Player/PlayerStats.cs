using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : BaseStatSystem
{
    public Image Hp;
    public Image Mp;
    private Animator animator;
    public bool die = false;
    public bool dead = false;
  
    private void Start()
    {
        if (Hp == null) Hp = MainUIManager.Instance.hpImg;
        if (Mp == null) Mp = MainUIManager.Instance.mpImg;
        caculatorStats(level);
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        
        Hp.fillAmount = currentHeath / maxHeath;
        Mp.fillAmount = currentMana / maxMana;
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
