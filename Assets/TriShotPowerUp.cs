using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriShotPowerUp : MonoBehaviour
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

        IEnumerator Pickup(Collider2D player)
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
}
