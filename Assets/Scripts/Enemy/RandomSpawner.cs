using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
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
    public System.Random r = new System.Random();


    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawn && Time.time > startTime + waitInSeconds)
        {

            nextSpawn = Time.time + r.Next((int)spawnRate, (int)spawnRate+2);
          //  randX = Random.Range(-8.4f, 8.4f);
          
            whereToSpawn = new Vector3(transform.position.x-(r.Next(0,290)), transform.position.y,transform.position.z);
            Instantiate(enemy, whereToSpawn, Quaternion.identity);
        }
        if(Time.time > spawnForSeconds + waitInSeconds)
        {
            Destroy(this);
        }
    }
}
