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

    Transform target;

    NavMeshAgent agent;

    EnemyStat stat;

    private float dmg;

    public GameObject enemyColider;

    public GameObject attackBox;

    

    private float cooldown = 10f;
    private bool die = false;

    private AudioSource playMoveSound,playDieSound;
    public AudioClip moveSound, dieSound;
    void Start()
    {
        target = playerManager.instance.Player.transform;
        agent = GetComponent<NavMeshAgent>();
        stat = GetComponent<EnemyStat>();
        instance = this;
        playMoveSound = GetComponent<AudioSource>();
        playDieSound = GetComponent<AudioSource>();
    }
 
    void Update()
    {
        dmg = playerManager.instance.Player.GetComponent<PlayerStats>().dmg;
        
        float distance = Vector3.Distance(target.position, transform.position);
        agent.speed = 0;

        if (distance <= lookRadius && distance>agent.stoppingDistance && !die)
        {
            playMoveSound.PlayOneShot(moveSound);
            agent.speed = moveSpeed;
            agent.SetDestination(target.position);
            animator.SetBool("isMoving", true);
        }
        else if(distance > lookRadius && distance > agent.stoppingDistance)
        {
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
                attackBox.GetComponent<Collider>().enabled = true;
                animator.SetBool("isMoving", false);
                StartCoroutine(AttackCooldown());
                animator.SetBool("isAttack", true);
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
            attackBox.GetComponent<Collider>().enabled = false;
        }

        if(stat.currentHeath <= 0&& !die)
        {
            playDieSound.PlayOneShot(dieSound);
            die = true;
            moveSpeed = 0f;
            enemyColider.GetComponent<Collider>().enabled = false;
            attackBox.GetComponent<Collider>().enabled = false;
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

        if(other.gameObject == other.CompareTag("Weapon"))
        {
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
        yield return new WaitForSeconds(cooldown);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}