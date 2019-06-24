using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideAndDown : Enemy
{
    // Start is called before the first frame update
    private Transform enemyPosition;


     
    void Start()
    {

        InvokeRepeating("MoveEnemy", 0f, 0.01f);
        enemyPosition = GetComponent<Transform>();
    }

    // Update is called once per frame
    void MoveEnemy()
    {
        enemyPosition.position += Vector3.right * speed/100;
        if(enemyPosition.position.x < XminBound || enemyPosition.position.x > XmaxBound)
        {
            speed = -speed;
            enemyPosition.position += Vector3.down * 15.0f;
            
        }


    }
}
