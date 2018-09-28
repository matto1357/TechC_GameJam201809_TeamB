using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKey : MonoBehaviour {

    //Inspectorで好きなボタンに変えられるようにする
    [SerializeField]
    KeyCode key1A;  // 1Pのアクションボタン
    [SerializeField]
    KeyCode key1U;  // 1Pの↑ボタン
    [SerializeField]
    KeyCode key1D;  // 1Pの↓ボタン
    [SerializeField]
    KeyCode key2A;  // 2Pのアクションボタン
    [SerializeField]
    KeyCode key2U;  // 2Pの↑ボタン
    [SerializeField]
    KeyCode key2D;  // 2Pの↓ボタン
	
	// Update is called once per frame
	void Update () {

        Comand();
	}

    public void Comand()
    {
        //各コマンドボタンの処理
        if (Input.GetKeyDown(key1A))
        {
            Debug.Log("key1A!");
        }

        if (Input.GetKey(key1U) && Input.GetKeyDown(key1A))
        {
            Debug.Log("key1U!");
        }

        if (Input.GetKey(key1D) && Input.GetKeyDown(key1A))
        {
            Debug.Log("key1D!");
        }

        if (Input.GetKeyDown(key2A))
        {
            Debug.Log("key2A!");
        } 

        if (Input.GetKey(key2U) && Input.GetKeyDown(key2A))
        {
            Debug.Log("key2U!");
        }

        if (Input.GetKey(key2D) && Input.GetKeyDown(key2A))
        {
            Debug.Log("key2D!");
        }

    }
}
