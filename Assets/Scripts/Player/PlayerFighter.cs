using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFighter : MonoBehaviour
{
    private Animator anim;
    public float coolDownTime = 2f;
    private float nextFireTime = 0f;
    public static int noOfClick = 0;
    private float lastClickTime = 0f;
    private float maxComboDelay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(1).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(1).IsName("Attack01"))
        {
            anim.SetBool("Attack1", false);
        }
        if (anim.GetCurrentAnimatorStateInfo(1).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(1).IsName("Attack02"))
        {
            anim.SetBool("Attack2", false);
        }
        if (anim.GetCurrentAnimatorStateInfo(1).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(1).IsName("Attack03"))
        {
            anim.SetBool("Attack3", false);
        }
        if (anim.GetCurrentAnimatorStateInfo(1).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(1).IsName("Attack04"))
        {
            anim.SetBool("Attack4", false);
            noOfClick = 0;
        }

        if (Time.time - lastClickTime > maxComboDelay)
        {
            noOfClick = 0;
        }
        if(Time.time > nextFireTime)
        {
            if (Input.GetAxis("Fire1") > 0)
            {
                OnClick();
            }
            if (Input.GetAxis("Fire2") > 0)
            {
                anim.SetBool("Defend",true);
            }
            if (Input.GetAxis("Fire2") == 0)
            {
                anim.SetBool("Defend", false);
            }
        }
    }

    void OnClick()
    {
        lastClickTime = Time.time;
        noOfClick++;
        if (noOfClick == 1)
        {
            anim.SetBool("Attack1", true);
        }
        noOfClick = Mathf.Clamp(noOfClick, 0, 4);
        if (noOfClick >= 2 && anim.GetCurrentAnimatorStateInfo(1).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(1).IsName("Attack01"))
        {
            anim.SetBool("Attack1", false);
            anim.SetBool("Attack2", true);
        }
        if (noOfClick >= 3 && anim.GetCurrentAnimatorStateInfo(1).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(1).IsName("Attack02"))
        {
            anim.SetBool("Attack2", false);
            anim.SetBool("Attack3", true);
        }
        if (noOfClick >= 4 && anim.GetCurrentAnimatorStateInfo(1).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(1).IsName("Attack03"))
        {
            anim.SetBool("Attack3", false);
            anim.SetBool("Attack4", true);
        }
    }
}