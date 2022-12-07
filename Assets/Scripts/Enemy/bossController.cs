using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class bossController : MonoBehaviour
{
    public static bossController instance;
    [SerializeField]
    private float lookRadius = 10f;
    [SerializeField]
    private float moveSpeed;
    public Animator animator;
    private bool isAttacking = false;
    private bool canHit = true;

    Transform target;

    NavMeshAgent agent;

    EnemyStat stat;

    private float dmg;

    public GameObject[] attackBox;
    public int ID;

    private float cooldown = 7f;
    private float skillMove;
    private bool die = false;

    void Start()
    {
        
        agent = GetComponent<NavMeshAgent>();
        stat = GetComponent<EnemyStat>();
        instance = this;
    }

    void Update()
    {
        if(target == null) target = playerManager.instance.Player.transform;
        dmg = playerManager.instance.Player.GetComponent<PlayerStats>().dmg;
        
        float distance = Vector3.Distance(target.position, transform.position);
        agent.speed = 0;

        if (distance <= lookRadius && distance > agent.stoppingDistance && !die)
        {
            agent.speed = moveSpeed;
            agent.SetDestination(target.position);
            animator.SetBool("isMoving", true);
        }
        else if (distance > lookRadius && distance > agent.stoppingDistance)
        {
            agent.speed = 0f;
            animator.SetBool("isMoving", false);
            animator.SetBool("isAttack", false);
            
        }
        if (distance <= agent.stoppingDistance && !die)
        {
            switch (ID)
            {
                case 1: AudioManager.Instance.PlayEffect("Boss"); break;
                case 2: AudioManager.Instance.PlayEffect("BossScorpion"); break;
            }
            //facetoface
            FaceTarget();
            //attack
            if (!isAttacking)
            {
                isAttacking = true;
                for (int i = 0; i < attackBox.Length; i++)
                {

                    attackBox[i].GetComponent<Collider>().enabled = true;
                }
                while (isAttacking)
                {
                    animator.SetInteger("skillMove", Random.Range(0, 4));
                    animator.SetTrigger("Attack");
                    return;

                }
                


            }
            else
            {
                isAttacking = false;
            }
        }
        else
        {
            
            for (int i = 0; i < attackBox.Length; i++)
            {

                attackBox[i].GetComponent<Collider>().enabled = false;
            }
        }

        if (stat.currentHeath <= 0)
        {
            switch (ID)
            {
                case 1: AudioManager.Instance.PlayEffect("BossDead"); break;
                case 2: AudioManager.Instance.PlayEffect("BossScorpion"); break;
            }
            die = true;
            moveSpeed = 0f;
            if(ID==1)
            {
                MainUIManager.Instance.ShowUIWinGame();
            }
            
            for (int i = 0; i < attackBox.Length; i++)
            {

                attackBox[i].GetComponent<Collider>().enabled = false;
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            canHit = true;
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == playerManager.instance.Player.gameObject)
        {
            stat.DealDmg(other.gameObject);
            PlayerMovement.instance.GetComponent<Animator>().SetTrigger("Hit");
            Debug.Log("mau con");
            StartCoroutine(AttackCooldown());
        }
        

        if (other.gameObject == other.CompareTag("Weapon")&& canHit)
        {
            canHit = false;
            stat.TakeDmg(dmg);
            StartCoroutine(AttackCooldown());
        }

        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == playerManager.instance.Player.gameObject)
        {

        }
        if (other.gameObject == other.CompareTag("Weapon"))
        {
            canHit = false;


        }

    }

    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(cooldown);
    }
    IEnumerator Attack()
    {
        while (isAttacking)
        {
            yield return new WaitForSeconds(10f);
            
            animator.SetInteger("skillMove", Random.Range(0, 4));
            animator.SetTrigger("Attack");


        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
