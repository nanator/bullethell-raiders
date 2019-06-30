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
    public float nextSpawn = 1.0f;
    private float startTime = 0.0f;
    public float spawnForSeconds = 5.0f;
    

    void Start()
    {
        startTime = nextSpawn;//Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad > nextSpawn)
        {
            nextSpawn = Time.timeSinceLevelLoad + spawnRate;
            //  randX = Random.Range(-8.4f, 8.4f);

            whereToSpawn = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Instantiate(enemy, whereToSpawn, Quaternion.identity);
        }
        if (Time.timeSinceLevelLoad > spawnForSeconds + startTime)
        {
            Destroy(this);
        }
    }
}

