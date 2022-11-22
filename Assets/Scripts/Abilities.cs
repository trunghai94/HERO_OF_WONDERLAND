using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoBehaviour
{
    [Header("Abilities 0")]
    public Image abilitiesImage0;
    public float cooldown0 = 5f;
    bool isCooldown = false;


    // Start is called before the first frame update
    void Start()
    {
        abilitiesImage0.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Abilities0();
    }

    void Abilities0()
    {
        if(Input.GetKey(KeyCode.LeftShift) && isCooldown == false)
        {
            isCooldown = true;
            abilitiesImage0.fillAmount = 1;
        }

        if (isCooldown)
        {
            abilitiesImage0.fillAmount -= 1 / cooldown0 * Time.deltaTime;
            if(abilitiesImage0.fillAmount <= 0)
            {
                abilitiesImage0.fillAmount = 0f;
                isCooldown = false;
            }
        }
    }
}
