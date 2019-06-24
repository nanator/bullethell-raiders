using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform player;
 
    public float speed = 20;
    public int health = 100;
    public float XmaxBound, XminBound, Ymaxbound, YminBound;
    public GameObject shield;
    public GameObject[] powerUps;
    public int powerUpChance;
    bool isAndroid = false;

    private bool touchStart = false;
    private Vector2 pointA;
    private Vector2 pointB;


    void Start()
    {
       
        if (Application.platform == RuntimePlatform.Android)
        {
            isAndroid = true;
        }
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
        /**
        //steuerung PC
        float b = Input.GetAxis("Horizontal");
        float h = Input.GetAxis("Vertical");
        if (player.position.x < XminBound && b < 0)  // check game boundaries
            b = 0;
        else if (player.position.x > XmaxBound && b > 0)
            b = 0;

        if (player.position.y < YminBound && h < 0)
            h = 0;
        else if (player.position.y > Ymaxbound && h > 0)
            h = 0;


        player.position += Vector3.right * b ; //actual movement
        player.position += Vector3.up * h ;
        */
        if (Input.GetMouseButtonDown(0))
        {
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }

        if (Input.GetMouseButton(0))
        {
            touchStart = true;
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }
        else
        {
            touchStart = false;
        }
        if (touchStart)
        {
            Vector2 offset = pointB - pointA;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
            moveCharacter(direction );

        }
    }
        void moveCharacter(Vector2 direction)
        {
            player.Translate(direction * speed * Time.deltaTime);
        }

        public void DropPowerUp(Vector2 enemyPostition)
    {
        if(Random.Range(0, 100) < powerUpChance)
        {
            Instantiate(powerUps[Random.Range(0, powerUps.Length)], enemyPostition, new Quaternion(0,0,0,0));
        }
    }

}
