using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static float screenheight;
    public static float screenwidth;
    public static float squad, timer;
    public static bool immortal = true;
    private void Start()
    {
        screenheight = Camera.main.orthographicSize * 2;
        screenwidth = screenheight * (Screen.width * 1f / Screen.height);
        squad = 0;
        timer = 6f;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 5) immortal = false;
        else immortal = true;
        if (timer < 0)
        {
            squad++;
            timer = 7f;
            if (squad > 3) squad = 0;
        }
    }
}
