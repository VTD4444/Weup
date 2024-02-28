using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIGameManager : MonoBehaviour
{
    public GameObject winPanel, losePanel;
    public Text scoreText, scoreWinText, timeWinText, scoreLoseText, timeLoseText;
    private float timePlay;
    public static UIGameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        timePlay = 0;
        PlayerController.score = 0;
        PlayerController.hp = 10f;
    }

    private void Update()
    {
        timePlay += Time.deltaTime;
        scoreText.text = "Score: " + PlayerController.score;
    }

    public void Home()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.click);
        SceneManager.LoadScene("Home");
        Time.timeScale = 1;
    }

    public void PlayAgain()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.click);
        Time.timeScale = 1;
        SceneManager.LoadScene("GamePlay");
    }

    public void WinGame()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.win);
        winPanel.SetActive(true);
        Time.timeScale = 0;
        scoreWinText.text = "" + PlayerController.score;
        timeWinText.text = (int)timePlay + "s";
    }

    public void LoseGame()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.lose);
        losePanel.SetActive(true);
        PlayerController.hp = 0;
        Time.timeScale = 0;
        losePanel.SetActive(true);
        scoreLoseText.text = "" + PlayerController.score;
        timeLoseText.text = (int)timePlay + "s";
    }
}