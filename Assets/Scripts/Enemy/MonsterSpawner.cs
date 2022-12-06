using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyStat))]
public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private float lookRadius = 10f;
    public Animator animator;
    private bool isActive = false;
    Transform target;
    EnemyStat stat;
    private bool die = false;
    private int counter;
    public int numberOfEnemies;
    public bool haveEyes;
    public GameObject[] enemies;
    public int maxLevel;
    public int minLevel;
    public float waitSecond;
    private float dmg;
    public Transform spawner;
    private bool canSpawn = true;
    public int levelAdd;

    public GameObject[] wall;
    public GameObject[] unlocker;
    void Start()
    {
        
        spawner = gameObject.GetComponent<Transform>();
        stat = GetComponent<EnemyStat>();
        counter = numberOfEnemies;
        
        for (int i = 0; i < wall.Length; i++)
        {
            wall[i].gameObject.SetActive(false);
        }


    }
   
    private void Update()
    {
        if (target == null) target = playerManager.instance.Player.transform;
        counter = Mathf.Clamp(counter, 0, numberOfEnemies);
        dmg = playerManager.instance.Player.GetComponent<PlayerStats>().dmg;
        levelAdd = playerManager.instance.Player.GetComponent<PlayerStats>().level;
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<EnemyStat>().level = Random.Range(levelAdd+minLevel, levelAdd+maxLevel);
        }
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius && !die)
        {
            if (haveEyes)
            {
                FaceTarget();
            }
            animator.SetBool("active", true);

            for(int i = 0; i < wall.Length; i++)
            {
                wall[i].gameObject.SetActive(true);
            }

            isActive = true;
            if(isActive)
            {
                animator.SetBool("idle", isActive);
            }
            else
            {
                animator.SetBool("idle", isActive);
            }
            if (counter > 0&& canSpawn)
            {
                canSpawn = false;
                
                for (int i=counter; i > 0; i--)
                {
                    SpawnEnemy();
                    counter--;
                    StartCoroutine(Spawn());
                    
                }
            }
            

        }
        else
        {
            animator.SetBool("active",false);
            isActive = false;
        }
        if (stat.currentHeath <= 0)
        {
            canSpawn = false;
            animator.SetBool("active", false);
            animator.SetBool("idle", false);
            die = true;
            stat.Die();
            for (int i = 0; i < wall.Length; i++)
            {
                wall[i].gameObject.SetActive(false);
            }
            for (int i = 0; i < wall.Length; i++)
            {
                unlocker[i].gameObject.SetActive(true);
            }
        }
    }
    public void SpawnEnemy()
    {
        AudioManager.Instance.PlayEffect("Spawn");
        animator.SetTrigger("spawn");
        if (counter > 0)
        {
            Instantiate(enemies[Random.Range(0, enemies.Length)], new Vector3(spawner.transform.position.x + Random.Range(-5, 5), spawner.transform.position.y, spawner.transform.position.z + Random.Range(-5, 5)), Quaternion.identity);
        }
    }
    

    IEnumerator Spawn()
    {
        yield return new WaitForSecondsRealtime(waitSecond);
        if (counter <= 0)
        {
            counter=numberOfEnemies;
        }
        yield return new WaitForSecondsRealtime(1f);
        canSpawn = true;






    }
    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(10f);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
    }
    private void OnTriggerEnter(Collider other)
    {
       

        if (other.gameObject == other.CompareTag("Weapon"))
        {
            stat.TakeDmg(dmg);
            StartCoroutine(AttackCooldown());
        }

    }

}
