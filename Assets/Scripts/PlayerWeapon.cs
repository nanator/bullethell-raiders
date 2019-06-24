using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public bool dualShoot;
    public Transform dualShoot1;
    public Transform dualShoot2;
    public bool triShoot;

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
        if (dualShoot)
        {
            Instantiate(bulletPrefab, dualShoot1.position, dualShoot1.rotation);
            Instantiate(bulletPrefab, dualShoot2.position, dualShoot2.rotation);

        }
        else if (triShoot)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Instantiate(bulletPrefab, dualShoot1.position, dualShoot1.rotation);
            Instantiate(bulletPrefab, dualShoot2.position, dualShoot2.rotation);
        }
        else
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}
