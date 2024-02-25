using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private void Update()
    {
        transform.position += 3f * Time.deltaTime * Vector3.down;
    }
}