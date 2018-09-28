using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegActionScript : MonoBehaviour
{
    [SerializeField]
    ActionControler acc;
    
    //コントローラーのボタンが押されたら発動、コントローラーのIDを見て判断
    public void MoveLeg(int controllerID)
    {
        List<GameObject> targetObj = new List<GameObject>();
        switch(controllerID)
        {
            //たこ
            case 0:
                targetObj = acc.octopusLeg;
                break;
            //シャチ
            case 1:
                targetObj = acc.killerWhaleTailFin;
                break;
        }
        for(int i = 0; i < targetObj.Count; i++)
        {
            //動き
            Debug.Log("aaa");
        }
    }
}
