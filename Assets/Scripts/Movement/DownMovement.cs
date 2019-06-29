using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownMovement : Enemy
{

    private Transform enemyPosition;



    void Start()
    {

        InvokeRepeating("MoveEnemy", 0f, 0.01f);
        enemyPosition = GetComponent<Transform>();
    }
    // Update is called once per frame
    void MoveEnemy()
    {
        enemyPosition.position += Vector3.down * speed / 100;
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Border"))
            {
                Destroy(gameObject);
            }
        }
    }

}
