using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour {

    //minの座標からmaxの座標まで背景が動く
    float min = -7;
    float max = 7;

    //背景の動くスピード（調整可）
    [SerializeField]
    public float speed;
	
	// Update is called once per frame
	void Update () {

        TransPostion();
	}

    public void TransPostion()
    {

        transform.position = new Vector2(0, Mathf.Lerp(min, max, Time.time * speed));

    }
}
