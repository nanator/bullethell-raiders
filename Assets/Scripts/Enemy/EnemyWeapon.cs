using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public bool ready = true;

    //Sound Klassen Source für Objekt, Clip für Sound der abgespielt wird
    public AudioClip SoundClip;
    public AudioSource SoundSource;

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

        SoundSource.clip = SoundClip;
    }

    void Shoot()
    {
        SoundSource.Play();
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        ready = true;
    }
}
