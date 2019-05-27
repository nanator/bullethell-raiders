using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public bool ready = true;

    // Update is called once per frame
    void Start()
    {
        InvokeRepeating("Shoot", 0.5f, 0.5f);
       /*
       if(ready)
        {
            float x = Random.value;
            Invoke("Shoot", x);//ruft methode nach delay auf
        }        
        ready = false;
        */
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        ready = true;
    }
}
