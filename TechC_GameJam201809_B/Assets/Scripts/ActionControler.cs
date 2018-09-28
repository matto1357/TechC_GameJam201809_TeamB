using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionControler : MonoBehaviour {
    //変数類
    [SerializeField]private GameObject octopus;//たこ足
    [SerializeField]private GameObject killerWhale;//シャチ尾びれ
    [SerializeField]private GameObject parentObj;//親になる予定
    [SerializeField]private Vector3 pos;//インスタンス化するpos 

    public List<GameObject> octopusLeg;
    public List<GameObject> killerWhaleTailFin;

    [SerializeField]private GameObject instancePosObj;
    private GameObject obj;

    private bool isPlay = true;

    private void Start()
    {
        InstanceLegObject();
        StartCoroutine(InstanceLegFrequency());
    }
    private void Update()
    {
     
        
        if (Input.GetMouseButtonDown(0))
        {
            isPlay = false;
            //ButtonInstruction(GameObject.Find("Octopus"));
            InstanceLegObject();
        }
        if (Input.GetMouseButtonDown(1))
        {
            isPlay = false;
            //ButtonInstruction(GameObject.Find("KillerWhale"));
            InstanceLegObject();
        }
        
    }

    //ABどちらのボタンを押すかの判定。いまのところは文字列をreturnする
    public string ButtonInstruction(GameObject obj)
    {
        string str = "";
        switch (obj.tag)
        {
            case "Octopus":
                str = "A";

                break;
            case "KillerWhale":
                str = "B";

                break;
        }

        //Debug.Log(str);
        return str;
    }
    //たこ足とシャチ尾びれのobjectをinstance化する関数
    public void InstanceLegObject()
    {
        int rnd = Random.Range(0,2);
        
        switch (rnd)
        {
            case 0:
                obj = Instantiate(octopus, pos, Quaternion.identity) as GameObject;
                octopusLeg.Add(obj);
                break;
            case 1:
                obj = Instantiate(killerWhale, pos, Quaternion.identity) as GameObject;
                killerWhaleTailFin.Add(obj);
                break;
        }
        obj.transform.SetParent(parentObj.transform);
        //Debug.Log(octopusLeg[0]);
        //Debug.Log(killerWhaleTailFin.Count);
    }
    
    IEnumerator InstanceLegFrequency()
    {
        while (true)
        {
            if (/*isPlay*/!isPlay) break;
            if(instancePosObj.transform.position.x - obj.transform.position.x >= 5)
            {

                InstanceLegObject();
            }

            yield return null;
        }
    }
}
