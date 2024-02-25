using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject enemyBullet;
    private float fireRate = 3f;

    private void Update()
    {
        if(!GameManager.immortal) Shoot();
    }

    private void Shoot()
    {
        fireRate -= Time.deltaTime;
        if (fireRate < 0)
        {
            Instantiate(enemyBullet, transform.position + new Vector3(0, -0.3f, 0), Quaternion.identity);
            fireRate = 2f;
        }
    }
}