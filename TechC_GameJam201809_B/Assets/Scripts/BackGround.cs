using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour {

    //minからmaxまでの座標間で動く
    [SerializeField]
    float min = -7;
    [SerializeField]
    float max = 7;

    //背景の高さ
    [SerializeField]
    [Range(0,100)]public float height;
    
    int stageMax;

    private void Start()
    {
        stageMax = GameController.Instance.sData.stageRange;
    }

    // Update is called once per frame
    void Update () {

        TransPostion(0);
        
	}

    public void TransPostion(float Height)
    { 
        this.transform.position = new Vector3(0, Mathf.Lerp(min, max, Height / stageMax) ,0);
        //this.transform.position = new Vector3(0, Mathf.Sin(Time.time) * Height, 0);
    }

}
