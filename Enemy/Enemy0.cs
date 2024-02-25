using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy0 : MonoBehaviour
{
    private float hp = 5f;

    private void Update()
    {
        if(GameManager.squad == 0) Square();
        else if(GameManager.squad == 1) Rhombus();
        else if(GameManager.squad == 2) Triangle();
        else if(GameManager.squad == 3) Rectangle();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!GameManager.immortal)
        {
            if (other.gameObject.tag == "PlayerBullet")
            {
                Destroy(other.gameObject);
                hp--;
                if (hp <= 0)
                {
                    AudioManager.Instance.PlaySFX(AudioManager.Instance.kill);
                    Destroy(gameObject);
                    PlayerController.score++;
                    if (PlayerController.score == 16 && PlayerController.hp > 0) UIGameManager.Instance.WinGame();
                }
            }
        }
    }

    private void Square()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(-1.7f,4.24f,0), 3f * Time.deltaTime);
    }

    private void Rhombus()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(-1.4f,3.54f,0), 1f * Time.deltaTime);
    }

    private void Triangle()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(-1.2f,3.3f,0), 1f * Time.deltaTime);
    }

    private void Rectangle()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(-1.4f,4.3f,0), 1f * Time.deltaTime);
    }
}
