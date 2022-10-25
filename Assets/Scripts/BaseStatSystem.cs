using UnityEngine;

public class BaseStatSystem : MonoBehaviour
{
    public float maxHeath;
    public float basicHP;
    public int level;
    public float currentHeath { get; private set; }

    public StatSystem str;
    public StatSystem agi;

    private void Awake()
    {
        currentHeath = maxHeath;
        
    }

    private void Update()
    {
        
    }


    public void TakeDmg(int str)
    {
        str -= agi.getValue();
        str = Mathf.Clamp(str, 0 ,int.MaxValue);
        currentHeath -= str;
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
            
            atm.TakeDmg(str.getValue());
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
        maxHeath =basicHP + ((10 * LVL) / Mathf.Sqrt(LVL));
        Debug.Log("max heath: " + maxHeath);
    }
}