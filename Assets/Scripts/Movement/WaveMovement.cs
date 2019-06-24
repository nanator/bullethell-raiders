using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMovement : MonoBehaviour
{
    // Start is called before the first f

    [SerializeField]
    float moveSpeed = 5f;

    [SerializeField]
    float frequency = 20f;

    [SerializeField]
    float magnitude = 0.5f;

    Vector3 pos, localScale;

    float spawnTime;
    void Start()
    {
        spawnTime = Time.time;
        pos = transform.position;

        localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    public void move()
    {
        pos += Vector3.down * Time.deltaTime * moveSpeed;
        transform.position = pos + transform.right * Mathf.Sin((Time.time - spawnTime) * frequency) * magnitude;
    }
}


