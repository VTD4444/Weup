using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy12 : MonoBehaviour
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
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(1.7f,1f,0), 3f * Time.deltaTime);
    }

    private void Rhombus()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(1.4f,1.98f,0), 1f * Time.deltaTime);
    }

    private void Triangle()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(1.2f,2.3f,0), 1f * Time.deltaTime);
    }

    private void Rectangle()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(1.4f,3.1f,0), 1f * Time.deltaTime);
    }
}
