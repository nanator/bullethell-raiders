using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnermoving : Enemy
{
    // Start is called before the first frame update
    public GameObject enemy;
    float randX;
    Vector3 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;
    public float waitInSeconds = 1.0f;
    private float startTime;
    public float spawnForSeconds = 5.0f;
    private Transform enemyPosition;

    void Start()
    {
        startTime = Time.time;
        enemyPosition = GetComponent<Transform>();


    }

    // Update is called once per frame
    void Update()
    {

        if(Time.time > nextSpawn && Time.time > startTime + waitInSeconds)
        {
            nextSpawn = Time.time + spawnRate;
          //  randX = Random.Range(-8.4f, 8.4f);
          
            whereToSpawn = new Vector3(transform.position.x, transform.position.y,transform.position.z);
            Instantiate(enemy, whereToSpawn, Quaternion.identity);
            MoveEnemy();
            
        }
        if(Time.time > spawnForSeconds + waitInSeconds)
        {
            Destroy(this);
        }
    }
    void MoveEnemy()
    {
        enemyPosition.position += Vector3.down * speed / 100;
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Border"))
            {
                Destroy(gameObject);
            }
        }
    }
}
