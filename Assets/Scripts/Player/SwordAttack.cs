using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public static SwordAttack instance;
    public float delayToDestroy = 5;
    public GameObject swordAttack;
    public GameObject swordAirAttack;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void SwordAirAttack()
    {
        var swordAirVfx = Instantiate(swordAirAttack,this.transform) as GameObject;
        swordAirVfx.transform.SetParent(this.transform);
        StartCoroutine(swordAttackDelay());
        Destroy(swordAirVfx, delayToDestroy);
    }

    IEnumerator swordAttackDelay()
    {
        yield return new WaitForSeconds(3);
        var swordVfx = Instantiate(swordAttack, this.transform) as GameObject;
        swordVfx.transform.SetParent(this.transform);
        Destroy(swordVfx, delayToDestroy);
    }
}
