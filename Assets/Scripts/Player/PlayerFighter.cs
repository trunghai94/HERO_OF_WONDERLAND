using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFighter : MonoBehaviour
{
    private Animator anim;
    private float nextFireTime = 1f;
    private float lastClickTime = 0f;
    private float maxComboDelay = 1f;

    public float coolDownTime = 2f;
    public int noOfClick = 0;
    public GameObject weaponObj;
    enemyController enemyHit;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (anim.GetCurrentAnimatorStateInfo(1).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(1).IsName("Attack01"))
        //{
        //    anim.SetBool("Attack1", false);
        //}
        //else if (anim.GetCurrentAnimatorStateInfo(1).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(1).IsName("Attack02"))
        //{
        //    anim.SetBool("Attack2", false);
        //}
        //else if (anim.GetCurrentAnimatorStateInfo(1).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(1).IsName("Attack03"))
        //{
        //    anim.SetBool("Attack3", false);
        //}
        //else if (anim.GetCurrentAnimatorStateInfo(1).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(1).IsName("Attack04"))
        //{
        //    anim.SetBool("Attack4", false);
        //    noOfClick = 0;
        //}

        if (Time.time - lastClickTime > maxComboDelay)
        {
            noOfClick = 0;
            anim.SetBool("Attack1", false);
        }

        if (Time.time > nextFireTime)
        {
            if (Input.GetMouseButton(0))
            {
                noOfClick++;
                OnClick();
                weaponObj.GetComponent<Collider>().enabled = true;
                StartCoroutine(CheckCollier());
            }
            if (Input.GetMouseButtonDown(1))
            {
                anim.SetBool("Defend", true);
            }
            if (Input.GetMouseButtonUp(1))
            {
                anim.SetBool("Defend", false);
            }
            
        }
    }

    void OnClick()
    {
        lastClickTime = Time.time;
        noOfClick = Mathf.Clamp(noOfClick, 0, 8);
        Debug.Log("noOfClick: " + noOfClick);
        if (noOfClick == 1)
        {
            anim.SetBool("Attack1", true);
            AudioManager.Instance.PlayEffect("Sword_sfx");
        }
        else if (noOfClick >= 2 && anim.GetCurrentAnimatorStateInfo(1).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(1).IsName("Attack01"))
        {
            //anim.SetBool("Attack1", false);
            //anim.SetBool("Attack2", true);
            anim.SetTrigger("attack02");
            AudioManager.Instance.PlayEffect("Sword_sfx");
        }
        else if (noOfClick >= 3 && anim.GetCurrentAnimatorStateInfo(1).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(1).IsName("Attack02"))
        {
            //anim.SetBool("Attack2", false);
            //anim.SetBool("Attack3", true);
            anim.SetTrigger("attack02");
            AudioManager.Instance.PlayEffect("Sword_sfx");
        }
        else if (noOfClick >= 4 && anim.GetCurrentAnimatorStateInfo(1).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(1).IsName("Attack03"))
        {
            //anim.SetBool("Attack3", false);
            //anim.SetBool("Attack4", true);
            anim.SetTrigger("attack02");
            AudioManager.Instance.PlayEffect("Sword_sfx");
            noOfClick = 0;
        }
    }

    IEnumerator CheckCollier()
    {
        yield return new WaitForSeconds(1f);
        weaponObj.GetComponent<Collider>().enabled = false;
    }
}
