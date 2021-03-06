﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleController : SingletonMonoBehaviour<TitleController> {

    [SerializeField]
    GameObject pauseUI;

    [SerializeField]
    Gauss gauss;

    bool isStart = false;
    float intencity = 0;

    public bool IsStart
    {
        get
        {
            return isStart;
        }

        set
        {
            isStart = value;
        }
    }

    void Update()
    {
        var deltaTime = Time.deltaTime;
        
        if (!isStart)
        {
            pauseUI.SetActive(true);
            intencity += deltaTime * 8;
        }
        else
        {
            pauseUI.SetActive(false);
            intencity -= deltaTime * 8;
        }
        intencity = Mathf.Clamp01(intencity);
        gauss.Resolution = (int)(intencity * 10);
    }
}
