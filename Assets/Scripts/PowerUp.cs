using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    private Transform powerUpPostion;
    public float speed;
    void Start()
    {

        InvokeRepeating("MovePowerUp", 0f, 0.01f);
        powerUpPostion = GetComponent<Transform>();
    }
    // Update is called once per frame
    void MovePowerUp()
    {
        powerUpPostion.position += Vector3.down * speed / 100;
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            StartCoroutine(Pickup(other));
        }
        if (other.CompareTag("Border"))
        {
            Destroy(gameObject);
        }
     
    }
    public abstract IEnumerator Pickup(Collider2D player);
}
