using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    
    //Sound Klassen Source für Objekt, Clip für Sound der abgespielt wird
    public AudioClip SoundClip;
    public AudioSource SoundSource;

    private void Start()
    {
        SoundSource.clip = SoundClip;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            SoundSource.Play();
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
