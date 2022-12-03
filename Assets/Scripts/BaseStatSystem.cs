using UnityEngine;

public class BaseStatSystem : MonoBehaviour
{
    public float maxHeath;
    public float maxMana;
    public float basicHP;
    public float basicMP;
    public int level;
    public float currentHeath { get; private set; }
    public float currentMana { get; private set; }

    public StatSystem str;
    public StatSystem agi;

    public float dmg;
    public float armor;

    private void Start()
    {
        
    }

    private void Awake()
    {
        caculatorStats(level);
        
        
        
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
    public void useMP(float MP)
    {
        currentMana -= MP;
    }
    public void regen(float HPregen, float MPregen)
    {
        currentHeath += HPregen;
        currentHeath = Mathf.Clamp(currentHeath, 0, maxHeath);
        currentMana += MPregen;
        currentMana = Mathf.Clamp(currentMana, 0, maxMana);
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
        maxMana = (basicMP + ((basicMP / LVL)/(LVL+5)));
        dmg = str.getValue()+((str.getValue()*LVL)+(str.getValue()/LVL));
        Debug.Log("dmg: " + dmg);
        armor = agi.getValue()+((agi.getValue()*LVL)+(agi.getValue()/LVL));
        Debug.Log("amor: "+ armor);
        currentHeath = maxHeath;
        currentMana = maxMana;
    }
    
}