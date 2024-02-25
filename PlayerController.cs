using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public VariableJoystick joystick;
    public Rigidbody2D rigidbody2D;
    private float speed = 200;
    public GameObject playerBullet;
    public Image bloodBar;
    public static float score = 0, hp = 10f;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private void Update()
    {
        Move();
        LimitPos();
    }

    private void Move()
    {
        Vector2 direction = new Vector2(joystick.Horizontal, joystick.Vertical);
        rigidbody2D.velocity = speed * Time.deltaTime * direction;
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            Instantiate(playerBullet, gameObject.transform.position + new Vector3(0,0.8f,0), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.hurt);
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            hp -= 3f;
            bloodBar.fillAmount = hp / 10;
            score++;
            if (hp < 0) UIGameManager.Instance.LoseGame();
            else if (score == 16) UIGameManager.Instance.WinGame();
        }
        else if (other.gameObject.tag == "EnemyBullet")
        {
            Destroy(other.gameObject);
            hp -= 1f;
            bloodBar.fillAmount = hp / 10;
            if (hp < 0) UIGameManager.Instance.LoseGame();
        }
    }

    private void LimitPos()
    {
        if (gameObject.transform.position.x < -GameManager.screenwidth / 2)
        {
            gameObject.transform.position =
                new Vector3(-GameManager.screenwidth / 2, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        
        if (gameObject.transform.position.x > GameManager.screenwidth / 2)
        {
            gameObject.transform.position =
                new Vector3(GameManager.screenwidth / 2, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        
        if (gameObject.transform.position.y < -GameManager.screenheight / 2)
        {
            gameObject.transform.position =
                new Vector3(gameObject.transform.position.x, -GameManager.screenheight / 2, gameObject.transform.position.z);
        }
        
        if (gameObject.transform.position.y > GameManager.screenheight / 2)
        {
            gameObject.transform.position =
                new Vector3(gameObject.transform.position.x, GameManager.screenheight / 2, gameObject.transform.position.z);
        }
    }
}