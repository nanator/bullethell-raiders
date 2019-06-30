using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUp : PowerUp
{
   

        public override IEnumerator Pickup(Collider2D player)
        {
            player.GetComponent<PlayerController>().shield.SetActive(true);
            


            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            

            yield return new WaitForSeconds(8f);
            player.GetComponent<PlayerController>().shield.SetActive(false);

            Destroy(gameObject);
        }
    }

