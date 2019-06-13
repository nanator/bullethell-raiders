using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diagonal : Enemy
{
    // Start is called before the first frame update
    private Transform enemyPosition;
    private int caseSwitch = 1;


    void Start()
    {

        InvokeRepeating("MoveEnemy", 0f, 0.01f);
        enemyPosition = GetComponent<Transform>();
    }

    // Update is called once per frame
    void MoveEnemy()
    {
        switch (caseSwitch)
        {
            case 1:
                enemyPosition.position += Vector3.right * speed / 100;
                enemyPosition.position += Vector3.down * speed / 100;
                if (enemyPosition.position.x > XmaxBound)
                    caseSwitch = 2;
                break;

            case 2:
                enemyPosition.position += Vector3.left * speed / 100;
                enemyPosition.position += Vector3.down * speed / 100;
                if (enemyPosition.position.x < XminBound)
                    caseSwitch = 1;
                break;

            default:
               
                break;
        }
      

        




        
        if (enemyPosition.position.y < YminBound)
        {
            Destroy(gameObject);
        }

    }
}
