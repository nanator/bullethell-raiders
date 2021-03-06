﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 10;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = -transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerController player = hitInfo.GetComponent<PlayerController>();
        if (player != null)
        {
            player.TakeDamage(damage);
        }
        if (!hitInfo.CompareTag("PowerUp") && !hitInfo.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            
        }
    }
}
