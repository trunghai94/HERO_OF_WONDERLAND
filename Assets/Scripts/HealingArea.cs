using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingArea : MonoBehaviour
{
    private float waitSecond;
    public float lookRadius = 10f;
    Transform target;
    public float hp,mp;
    private bool heal;



    // Update is called once per frame
    void Update()
    {
        if (target == null) target = playerManager.instance.Player.transform;
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius)
        {
            heal = true;
            StartCoroutine(Heal());
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
    IEnumerator Heal()
    {
        yield return new WaitForSecondsRealtime(waitSecond);
        if (heal)
        {
            playerManager.instance.Player.GetComponent<PlayerStats>().regen(hp,mp);
        }
        yield return new WaitForSecondsRealtime(1f);
        heal = false;
    }
}
