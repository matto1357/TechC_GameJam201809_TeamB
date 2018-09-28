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
    public StageData sData;

    bool[] isStanby = new bool[2];

    enum GameState                          //ゲームの状態がどこにいるか
    {
        Title = 0,
        Game,
        Result
    }
    [SerializeField]
    private GameState _gameState = 0;       //いーなむ

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        // テストコード
        if (Input.GetKeyDown(KeyCode.Q)) isStanby[0] = true;
        if (Input.GetKeyDown(KeyCode.W)) isStanby[1] = true;

        switch (_gameState)
        {
            case GameState.Title:
                if (isStanby[0] && isStanby[1])
                {
                    TitleController.Instance.IsStart = true;
                    _gameState = GameState.Game;
                }
                return;

            case GameState.Game:
                TimeLapse();
                return;

            case GameState.Result:
                return;

        }
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

    public void GameOver()
    {

        
    }

    public void GameClear()
    {

    }

    void Result()
    {
        _gameState = GameState.Result;
        ResultController.Instance.IsStart = true;
    }

}