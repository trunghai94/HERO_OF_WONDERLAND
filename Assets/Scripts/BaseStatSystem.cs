using UnityEngine;

public class BaseStatSystem : MonoBehaviour
{
    public float maxHeath = 100f;
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
        if(currentHeath <= 0)
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
    public virtual void Die()
    {

        Debug.Log(transform.name + "died.");
    }
}