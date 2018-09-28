using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegActionScript : MonoBehaviour
{
    //仮
    List<GameObject> aaa = new List<GameObject>();
    
    //コントローラーのボタンが押されたら発動、コントローラーのIDを見て判断
    public void MoveLeg(int controllerID)
    {
        List<GameObject> targetObj = new List<GameObject>();
        switch(controllerID)
        {
            //たこ
            case 0:
                targetObj = aaa;
                break;
            //シャチ
            case 1:
                targetObj = aaa;
                break;
        }
        for(int i = 0; i < targetObj.Count; i++)
        {
            //targetObj[i].処理
        }
    }
}
