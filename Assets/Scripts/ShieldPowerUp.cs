using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    public GameObject pickupEffect;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Pickup(other));
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
