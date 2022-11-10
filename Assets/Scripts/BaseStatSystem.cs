using UnityEngine;

public class BaseStatSystem : MonoBehaviour
{
    public float maxHeath;
    public float basicHP;
    public int level;
    public float currentHeath { get; private set; }

    public StatSystem str;
    public StatSystem agi;

    public float dmg;
    public float armor;

    private void Awake()
    {
        caculatorStats(level);
        currentHeath = maxHeath;
    }

    private void Update()
    {
        
    }


    public void TakeDmg(float dmg)
    {
        dmg -= armor;
        dmg = Mathf.Clamp(dmg, 0 ,int.MaxValue);
        currentHeath -= dmg;
        currentHeath = Mathf.Clamp(currentHeath, 0 ,int.MaxValue);
        Debug.Log(transform.name +"get" + str + "damages.");
        Debug.Log(transform.name + "con" + currentHeath + "HP");
        if (currentHeath <= 0)
        {
            Die();
        }
    }

    public void DealDmg(GameObject target)
    {
        var atm = target.GetComponent<BaseStatSystem>();
        
        if(atm != null)
        {
            atm.TakeDmg(dmg);
        }
    }

    public void regen(float HPregen)
    {
        currentHeath += HPregen;
        currentHeath = Mathf.Clamp(currentHeath, 0, maxHeath);
    }

    public virtual void Die()
    {
        Debug.Log(transform.name + "died.");
    }

    public void caculatorStats(int level)
    {
        int LVL = Mathf.Clamp(level - 1, 1,int.MaxValue);
        maxHeath =((basicHP * LVL) / Mathf.Sqrt(LVL));
        Debug.Log("max heath: " + maxHeath);
        dmg = str.getValue()+((str.getValue()*LVL)+(str.getValue()/LVL));
        Debug.Log("dmg: " + dmg);
        armor = agi.getValue()+((agi.getValue()*LVL)+(agi.getValue()/LVL));
        Debug.Log("amor: "+ armor);
    }
    
}