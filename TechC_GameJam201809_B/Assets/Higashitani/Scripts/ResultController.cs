using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultController : SingletonMonoBehaviour<ResultController> {
    [SerializeField]
    GameObject resultUI;

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
    
	void Update () {
        var deltaTime = Time.deltaTime;

        if (isStart)
        {
            resultUI.SetActive(true);
            intencity += deltaTime * 8;
        }
        else
        {
            resultUI.SetActive(false);
            intencity -= deltaTime * 8;
        }
        intencity = Mathf.Clamp01(intencity);
        gauss.Resolution = (int)(intencity * 10);
    }

    public void TextChange(string text)
    {
        resultUI.GetComponent<Text>().text = text;
    }

}
