using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriShotPowerUp : PowerUp
{
   
        public override IEnumerator Pickup(Collider2D player)
        {

            PlayerWeapon weapon = player.GetComponent<PlayerWeapon>();
            weapon.triShoot = true;

            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;

            yield return new WaitForSeconds(10f);

            weapon.triShoot = false;
            Destroy(gameObject);
        }
    }

