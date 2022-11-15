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
    
    public Transform spawner;


    // Start is called before the first frame update
    void Start()
    {
        spawner = gameObject.GetComponent<Transform>();
        
        InvokeRepeating("SpawnEnemy", time, delay);
        for (int i = 0; i < enemies.Length; i++)
        {
           enemies[i].GetComponent<EnemyStat>().level = Random.Range(minLevel, maxLevel);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemy()
    {
        if(--counter == 0)
        {
            CancelInvoke("SpawnEnemy");          
        }
        Instantiate(enemies[Random.Range(0, enemies.Length)], new Vector3(spawner.transform.position.x + Random.Range(-5, 5), spawner.transform.position.y, spawner.transform.position.z + Random.Range(-5, 5)), Quaternion.identity);
    }
}
