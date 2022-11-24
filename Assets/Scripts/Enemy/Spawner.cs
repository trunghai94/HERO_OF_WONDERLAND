using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int counter;
    public int time;
    public float delay;
    public GameObject[] enemies;
    public int maxLevel;
    public int minLevel;
    [SerializeField]
    private float lookRadius = 10f;
    Transform target;
    private bool canSpawn = true;
    public AudioClip spawnSound;
    private AudioSource spawnSoundSource;
    public Transform spawner;


    // Start is called before the first frame update
    void Start()
    {
        spawner = gameObject.GetComponent<Transform>();
        target = playerManager.instance.Player.transform;
        spawnSoundSource = gameObject.GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        counter = Mathf.Clamp(counter, 0, counter);
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<EnemyStat>().level = Random.Range(minLevel, maxLevel);
        }
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius)
        {
            if (counter > 0 && canSpawn)
            {
                canSpawn = false;

                for (int i = counter; i > 0; i--)
                {
                    SpawnEnemy();
                    counter--;


                }
            }
        }
    }
    
    public void SpawnEnemy()
    {
        spawnSoundSource.PlayOneShot(spawnSound);
        
        if (counter > 0)
        {
            Instantiate(enemies[Random.Range(0, enemies.Length)], new Vector3(spawner.transform.position.x + Random.Range(-5, 5), spawner.transform.position.y, spawner.transform.position.z + Random.Range(-5, 5)), Quaternion.identity);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
