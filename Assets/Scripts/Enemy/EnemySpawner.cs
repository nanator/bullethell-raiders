using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    float randX;
    Vector3 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 1.0f;
    public float startTime;
    public float spawnForSeconds = 5.0f;


    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
          //  randX = Random.Range(-8.4f, 8.4f);
          
            whereToSpawn = new Vector3(transform.position.x, transform.position.y,transform.position.z);
            Instantiate(enemy, whereToSpawn, Quaternion.identity);
        }
        if(Time.time > spawnForSeconds + startTime)
        {
            Destroy(this);
        }
    }
}
