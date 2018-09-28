using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleController : MonoBehaviour {

    [SerializeField]
    GameObject pauseUI;

    [SerializeField]
    Gauss gauss;

    bool pauseFlag = false;
    float intencity = 0;
    float prevTime;

    void Update()
    {
        var deltaTime = Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.A))
        {
            pauseFlag = !pauseFlag;
        }
        if (pauseFlag)
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
