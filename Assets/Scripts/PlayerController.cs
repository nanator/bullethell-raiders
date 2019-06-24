using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
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

    private Vector3 touchPosition;
    private Rigidbody2D rb;
    private Vector3 direction;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
         

        Vector3 input = new Vector3(b,h,0) ;

       // player.position += Vector3.right * b * speed ; //actual movement
       // player.position += Vector3.up * h *speed ;

        input = Vector3.ClampMagnitude(input, 1); ;

       player.position += input * speed;

        if (isAndroid == true) // Steuerung Android
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.z = 0;
                direction = (touchPosition - transform.position);
                rb.velocity = new Vector2(direction.x, direction.y) * speed;

                if (touch.phase == TouchPhase.Ended)
                    rb.velocity = Vector2.zero;
            }


        }
    }



    public void DropPowerUp(Vector3 enemyPostition)
    {
        if(Random.Range(0, 100) < powerUpChance)
        {
            Instantiate(powerUps[Random.Range(0, powerUps.Length)], enemyPostition, new Quaternion(0,0,0,0));
        }
    }

}
