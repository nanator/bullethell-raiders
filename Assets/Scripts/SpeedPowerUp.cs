using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : PowerUp
{

    public float speedincrease;


        public override IEnumerator Pickup(Collider2D player)
        {
            Debug.Log("E");
            PlayerController stats = player.GetComponent<PlayerController>();
            stats.speed += speedincrease;

            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;

            yield return new WaitForSeconds(3f);

            stats.speed -= speedincrease;
            Destroy(gameObject);
        }
    }
