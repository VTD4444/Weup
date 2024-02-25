using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private float timeToDie = 2f;

    private void Update()
    {
        gameObject.transform.position += 5f * Time.deltaTime * Vector3.up;
        timeToDie -= Time.deltaTime;
        if (timeToDie <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "EnemyBullet")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
