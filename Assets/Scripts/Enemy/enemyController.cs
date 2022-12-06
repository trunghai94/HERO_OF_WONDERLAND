using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


[RequireComponent(typeof(EnemyStat))]
public class enemyController : MonoBehaviour
{
    public static enemyController instance;
    [SerializeField]
    private float lookRadius = 10f;
    [SerializeField]
    private float moveSpeed;
    public Animator animator;
    private bool isAttacking = false;
    public bool canHit = true;
    private bool isMoving = false;
    Transform target;

    NavMeshAgent agent;

    EnemyStat stat;

    private float dmg;

    public GameObject enemyColider;

    public GameObject[] attackBox;
    public int ID;
    

    private float cooldown = 0.1f;
    private bool die = false;

   
    void Start()
    {
        
        agent = GetComponent<NavMeshAgent>();
        stat = GetComponent<EnemyStat>();
        instance = this;
        
    }


    void Update()
    {
        
        if(target==null) target = playerManager.instance.Player.transform;
        dmg = playerManager.instance.Player.GetComponent<PlayerStats>().dmg;
        
        float distance = Vector3.Distance(target.position, transform.position);
        agent.speed = 0;

        if (distance <= lookRadius && distance>agent.stoppingDistance && !die)
        {
            if (!isMoving)
            {
                isMoving = true;
                switch (ID)
                {
                    case 1: AudioManager.Instance.PlayEffect("SlimeMove"); break;
                    case 2: AudioManager.Instance.PlayEffect("GloomMove"); break;
                    case 3: AudioManager.Instance.PlayEffect("GolemMove"); break;

                    default:
                        print("can't find ID");
                        break;
                }
            }

            agent.speed = moveSpeed;
            agent.SetDestination(target.position);
            animator.SetBool("isMoving", true);
        }
        else if(distance > lookRadius && distance > agent.stoppingDistance)
        {
            isMoving = false;
            agent.speed = 0f;
            animator.SetBool("isMoving",false);
            animator.SetBool("isAttack", false);
        }
        if (distance <= agent.stoppingDistance && !die)
        {
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
                animator.SetBool("isMoving", false);
                while (isAttacking)
                {
                    StartCoroutine(AttackCooldown());
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
            animator.SetBool("isAttack", false);
            isAttacking = false;
            for (int i = 0; i < attackBox.Length; i++)
            {

                attackBox[i].GetComponent<Collider>().enabled = false;
            }
            
        }

        if(stat.currentHeath <= 0&& !die)
        {
            switch (ID)
            {
                case 1: AudioManager.Instance.PlayEffect("SlimeDead"); break;
                case 2: AudioManager.Instance.PlayEffect("GloomDead"); break;
                case 3: AudioManager.Instance.PlayEffect("GolemDead"); break;

                default:
                    print("can't find ID");
                    break;
            }
            moveSpeed = 0f;
            enemyColider.GetComponent<Collider>().enabled = false;
            for (int i = 0; i < attackBox.Length; i++)
            {

                attackBox[i].GetComponent<Collider>().enabled = false;
            }
            die = true;
        }
        if(Input.GetMouseButtonUp(0))
        {
            canHit = true ;
        }
    }
   
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation,lookRotation,Time.deltaTime*5);
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

        if (other.gameObject == other.CompareTag("Weapon") && canHit)
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
            


        }

    }
    
    IEnumerator AttackCooldown()
    {
        
        animator.SetBool("isAttack", true);
        yield return new WaitForSeconds(cooldown);
        animator.SetBool("isAttack", false);
        


    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}