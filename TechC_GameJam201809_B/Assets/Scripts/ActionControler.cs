using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionControler : MonoBehaviour {
    //変数類
    [SerializeField]private GameObject octopus;//たこ足
    [SerializeField]private GameObject killerWhale;//シャチ尾びれ
    [SerializeField] private GameObject wallHigh;//高所の壁
    [SerializeField] private GameObject wallRow;//低所の壁
    [SerializeField]private GameObject parentObj;//親になる予定
    [SerializeField]private Vector3 pos;//インスタンス化するpos

    [SerializeField] private GameObject OctopusText;//たこ足のためのtext
    [SerializeField] private GameObject KillerWhaleText;//シャチ尾びれのためのtext

    public List<GameObject> octopusLeg;
    public List<GameObject> killerWhaleTailFin;

    [SerializeField]private GameObject instancePosObj;
    private GameObject obj;

    [SerializeField] float betweenPos;
    private bool isPlay = true;

    [SerializeField] int TextDeleteLegCount;

    [SerializeField]
    private GameController gc;

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
        }
        
    }
    //たこ足とシャチ尾びれのobjectをinstance化する関数
    public void InstanceLegObject()
    {
        int rnd = Random.Range(0,2);

        Vector3 textPos = pos;
        textPos.y = textPos.y + 3f;
        GameObject textObj = null;
        switch (rnd)
        {
            case 0:
                obj = Instantiate(octopus, pos, Quaternion.identity) as GameObject;
                var rot = obj.transform.rotation;
                obj.transform.rotation = Quaternion.Euler(rot.x, 100, rot.z);
                octopusLeg.Add(obj);
                if (GameController.Instance.legsCount >= TextDeleteLegCount) break;
                textObj = Instantiate(OctopusText, textPos, Quaternion.identity);
                textObj.transform.SetParent(obj.transform);
                break;
            case 1:
                obj = Instantiate(killerWhale, pos, Quaternion.identity) as GameObject;
                killerWhaleTailFin.Add(obj);
                if (GameController.Instance.legsCount >= TextDeleteLegCount) break;
                textObj = Instantiate(KillerWhaleText, textPos, Quaternion.identity);
                textObj.transform.SetParent(obj.transform);
                break;
        }
        obj.transform.SetParent(parentObj.transform);
        GameController.Instance.legsCount++;
        //Debug.Log(octopusLeg[0]);
        //Debug.Log(killerWhaleTailFin.Count);
    }
    
    IEnumerator InstanceLegFrequency()
    {
        while (true)
        {
            if (/*isPlay*/!isPlay) break;
            if(instancePosObj.transform.position.x - obj.transform.position.x >= betweenPos)
            {
                InstanceLegObject();
                InstenceWall();
            }

            yield return null;
        }
    }

    public void InstenceWall()
    {
        
        if (GameController.Instance.legsCount % 5 != 0) return;
        int rnd = Random.Range(0, 2);
        Vector3 textPos = pos;
        GameObject obj = null;
        switch (rnd) {
            case 0:
                textPos.y = textPos.y + 3.5f;
                textPos.x = textPos.x + 1.5f;
                obj = Instantiate(wallHigh, textPos, Quaternion.identity) as GameObject;
                obj.transform.SetParent(parentObj.transform);
                break;
            case 1:
                textPos.x = textPos.x + 1.5f;
                obj = Instantiate(wallRow, textPos, Quaternion.identity) as GameObject;
                obj.transform.SetParent(parentObj.transform);
                break;
        }
        
    }
}
