using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegActionScript : SingletonMonoBehaviour<LegActionScript>
{
    [SerializeField]
    LegInstance li;

    private void Start()
    {
        li = LegInstance.Instance;
    }

    //コントローラーのボタンが押されたら発動、コントローラーのIDを見て判断
    public void MoveLeg(int controllerID, ActionPower ap)
    {
        List<GameObject> targetObj = new List<GameObject>();
        switch(controllerID)
        {
            //たこ
            case 0:
                targetObj = li.octopusLegList;
                break;
            //シャチ
            case 1:
                targetObj = li.killerWhaleTailFinList;
                break;
        }
        for(int i = 0; i < targetObj.Count; i++)
        {
            //動き
            Debug.Log("aaa");
        }
    }
}
