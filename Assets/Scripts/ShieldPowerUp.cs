using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    public GameObject pickupEffect;

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
      

        IEnumerator Pickup(Collider2D player)
        {
            player.GetComponent<PlayerController>().shield.SetActive(true);
            


            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            

            yield return new WaitForSeconds(8f);
            player.GetComponent<PlayerController>().shield.SetActive(false);

            Destroy(gameObject);
        }
    }
}
