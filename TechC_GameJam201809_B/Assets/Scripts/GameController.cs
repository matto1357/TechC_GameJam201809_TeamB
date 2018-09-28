using System.Collections;
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
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        speed = 2.9f *Time.deltaTime;

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

}