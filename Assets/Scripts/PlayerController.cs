using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    private Transform player;
    public float speed;
    public int health = 100;
    public float XmaxBound, XminBound, Ymaxbound, YminBound;
    public GameObject shield;
    public GameObject[] powerUps;
    public int powerUpChance;

    void Start()
    {
        player = GetComponent<Transform>();
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity); //noch keine Todes Animation
        Destroy(gameObject);
        FindObjectOfType<GameManager>().GameOver();
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)//wenn man einen Gegner rammt sterben beide
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            Destroy(enemy.gameObject); //funktioniert noch nicht
            Die();
        }
        
    }
    
    // Update is called once per frame
    void Update()
    {
        float b = Input.GetAxis("Horizontal");
        float h = Input.GetAxis("Vertical");
        if (player.position.x < XminBound && b < 0)
            b = 0;
        else if (player.position.x > XmaxBound && b > 0)
            b = 0;

        if (player.position.y < YminBound && h < 0)
            h = 0;
        else if (player.position.y > Ymaxbound && h > 0)
            h = 0;


        player.position += Vector3.right * b * speed;
        player.position += Vector3.up * h * speed;

    }

    public void DropPowerUp(Vector2 enemyPostition)
    {
        if(Random.Range(0, 100) < powerUpChance)
        {
            Instantiate(powerUps[Random.Range(0, powerUps.Length)], enemyPostition, new Quaternion(0,0,0,0));
        }
    }

}
