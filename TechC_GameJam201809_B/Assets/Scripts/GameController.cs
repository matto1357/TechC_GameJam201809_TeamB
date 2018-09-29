﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : SingletonMonoBehaviour<GameController>
{
    //変数エリア
    private float gameTime = 120f;          //ゲーム残り時間
    public int legsCount = 0;               //現在生成が何本目か
    public int scoreCount = 0;              //通過した足が何本目か
    [SerializeField]
    public float speed;                     //ゲームスピード
    [SerializeField]
    public StageData sData;

	public Transform p1Plate, p2Plate;
	public Transform p1Cover, p2Cover;

    bool[] isStanby = new bool[2];

    public enum GameState                          //ゲームの状態がどこにいるか
    {
        Title = 0,
        Game,
        Result
    }
    [SerializeField]
    public GameState _gameState = 0;       //いーなむ

	// Use this for initialization
	void Start ()
    {
		p1Plate.gameObject.SetActive (true);
		p2Plate.gameObject.SetActive (true);
		p1Cover.gameObject.SetActive (true);
		p2Cover.gameObject.SetActive (true);
	}
	
	// Update is called once per frame
	void Update ()
    {
        speed = 2.9f *Time.deltaTime;

        // テストコード
		if (Input.GetKeyDown (KeyCode.S)) 
		{
			isStanby [0] = true;

			p1Cover.Rotate(new Vector3(0, 0, 1) * 50);
		}
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			isStanby[1] = true;
			p2Cover.Rotate(new Vector3(0, 0, -1) * 50);
		}
			
        switch (_gameState)
        {
            case GameState.Title:
                if (isStanby[0] && isStanby[1])
                {
					StartCoroutine (WaitFor (1));
                }
                return;

            case GameState.Game:
                TimeLapse();
                return;

            case GameState.Result:
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    _gameState = GameState.Title;
                    // 現在のScene名を取得する
                    Scene loadScene = SceneManager.GetActiveScene();
                    // Sceneの読み直し
                    SceneManager.LoadScene(loadScene.name);
                }
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

    public void AddLeg(int value = 1)     //スコア加算
    {
        legsCount += value;
    }

    public void AddScore(int value = 1)
    {
        scoreCount += value;
    }

    public void GameOver()
    {
        Result("GameOver…");
    }

    public void GameClear()
    {
        Result("GameClear");
    }

    void Result(string text)
    {
        _gameState = GameState.Result;
        ResultController.Instance.IsStart = true;
        ResultController.Instance.TextChange(text);
    }

	IEnumerator WaitFor(float duration)
	{
		yield return new WaitForSeconds (duration);

		TitleController.Instance.IsStart = true;
		_gameState = GameState.Game;

		p1Cover.gameObject.SetActive (false);
		p2Cover.gameObject.SetActive (false);

		p1Plate.gameObject.SetActive (false);
		p2Plate.gameObject.SetActive (false);
	}
}