using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class UIHomeManager : MonoBehaviour
{
    public GameObject[] btns, imgs;
    public GameObject optionPanel;

    private void Start()
    {
        Vector3 startPos = imgs[1].transform.position;
        imgs[1].transform.DOMoveY(startPos.y + 50f, 1f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }

    public void PlayGame()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.click);
        AudioManager.Instance.musicSource.Pause();
        foreach (GameObject btn in btns)
        {
            btn.transform.DOLocalMoveY(-Screen.height / 2, 2f).OnComplete(() =>
            {
                SceneManager.LoadScene("GamePlay");
            });
        }

        foreach (GameObject img in imgs)
        {
            img.transform.DOLocalMoveY(Screen.height / 2, 2f);
        }
    }

    public void OptionPanel()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.click);
        optionPanel.SetActive(true);
    }

    public void ClosePanel()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.click);
        optionPanel.SetActive(false);
    }

    public void QuitGame()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.click);
        Application.Quit();
    }
}