using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public bool ready = true;
    public float fireRate;
    //Sound Klassen Source für Objekt, Clip für Sound der abgespielt wird
    public AudioClip SoundClip;
    public AudioSource SoundSource;
    private float rand;

    // Update is called once per frame
    void Start()
    {
        rand = Random.Range(0.0f, 15.0f);
        InvokeRepeating("Shoot", 0.0f, fireRate);
        /*
        if(ready)
         {
             float x = Random.value;
             Invoke("Shoot", x);//ruft methode nach delay auf
         }        
         ready = false;
         */

        SoundSource.clip = SoundClip;
    }

    void Shoot()
    {
        SoundSource.Play();
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        ready = true;
    }
}
