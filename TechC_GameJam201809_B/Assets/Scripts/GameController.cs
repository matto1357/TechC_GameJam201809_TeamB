using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : SingletonMonoBehaviour<GameController>
{
    //変数エリア
    private float gameTime = 120f;          //ゲーム残り時間
    private int score = 0;                  //スコア
    public int legsCount = 0;               //現在の足の本数
    [SerializeField]
    public float speed;                     //ゲームスピード
    [SerializeField]
    StageData sData;

    enum gameState                          //ゲームの状態がどこにいるか
    {
        Title = 0,
        Game,
        Result
    }

    private gameState _gameState = 0;       //いーなむ

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        TimeLapse();
	}

    private void TimeLapse()                //タイム経過させる
    {
        gameTime -= Time.deltaTime;
        if (gameTime <= 0)
        {
            //ゲーム終了処理
        }
    }

    public void AddScore(int value = 1)     //スコア加算
    {
        score += value;
    }

    public void DeleteScore(int value = 1)  //スコア減算
    {
        score -= value;
        if(score < 0)
        {
            score = 0;
        }
    }
}