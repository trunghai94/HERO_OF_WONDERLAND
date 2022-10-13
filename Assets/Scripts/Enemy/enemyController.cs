using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemyStat))]
public class enemyController : MonoBehaviour
{
    [SerializeField]
    private float lookRadius = 10f;
    [SerializeField]
    private float moveSpeed;
    public Animator animator;
    private bool isAttacking = false;

    Transform target;

    NavMeshAgent agent;

    EnemyStat stat;

    public GameObject attackBox;


    
    private float cooldown = 10f;
    private bool hitting;

    void Start()
    {
        target = playerManager.instance.Player.transform;
        agent = GetComponent<NavMeshAgent>();
        stat = GetComponent<EnemyStat>();
    }


    void Update()
    {
        
        float distance = Vector3.Distance(target.position, transform.position);
        agent.speed = 0;

        if (distance <= lookRadius && distance>agent.stoppingDistance)
        {
            agent.speed = moveSpeed;
            agent.SetDestination(target.position);
            animator.SetBool("isMoving", true);
            

           
        }
        else if(distance > lookRadius && distance > agent.stoppingDistance)
        {
            agent.speed = 0;
            animator.SetBool("isMoving",false);
            animator.SetBool("isAttack", false);
        }
        if (distance <= agent.stoppingDistance)
        {
            //facetoface
            FaceTarget();
            //attack
            if (!isAttacking)
            {
                isAttacking = true;
                attackBox.GetComponent<Collider>().enabled = true;
                animator.SetBool("isMoving", false);
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
            

                stat.DealDmg(target.gameObject);
                Debug.Log("danh trung");
                StartCoroutine(AttackCooldown());
            
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == playerManager.instance.Player.gameObject)
        {
            hitting = false;
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