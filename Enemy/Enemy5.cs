using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy5 : MonoBehaviour
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
                    PlayerController.score++;
                    Destroy(gameObject);
                    if (PlayerController.score == 16 && PlayerController.hp > 0) UIGameManager.Instance.WinGame();
                }
            }
        }
    }
    private void Square()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(0.57f,3.16f,0), 3f * Time.deltaTime);
    }

    private void Rhombus()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(0.6f,2.76f,0), 1f * Time.deltaTime);
    }

    private void Triangle()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(1.8f,2.8f,0), 1f * Time.deltaTime);
    }

    private void Rectangle()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(2.1f,4.3f,0), 1f * Time.deltaTime);
    }
}
