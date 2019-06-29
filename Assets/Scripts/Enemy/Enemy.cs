using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;
    public GameObject deathEffect;

    public float XmaxBound, XminBound, Ymaxbound, YminBound;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);

        Destroy(gameObject);
        FindObjectOfType<PlayerController>().DropPowerUp(transform.position);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerController player = hitInfo.GetComponent<PlayerController>();
        if (hitInfo.gameObject.name == "Shield")
        {
            
            Die();
        }
        if(hitInfo.CompareTag("Player"))
        {
            
            Die();
            player.Die();
        }
        if (hitInfo.gameObject.name == "BottomCollider")
        {
            Die();
        }
    }
}