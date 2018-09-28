using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDelete : MonoBehaviour {

    GameObject obj;
    ActionControler actionControler;
	// Use this for initialization
	void Start () {
        obj = GameObject.Find("Manager");
        actionControler = obj.GetComponent<ActionControler>();
	}
	
	// Update is called once per frame
	void Update () {
        DeleteThisObject();
	}
    //このobjectをdeleteする関数
    private void DeleteThisObject()
    {
        if(this.transform.position.x <= -10)//position.xが一定位置を過ぎたら
        {

            switch (this.gameObject.tag)
            {
                case "Octopus":
                    actionControler.octopusLeg.Remove(this.gameObject);
                    break;
                case "KillerWhale":
                    actionControler.killerWhaleTailFin.Remove(this.gameObject);
                    break;
            }
            //Debug.Log(actionControler.octopusLeg[0]);
            //Debug.Log(actionControler.killerWhaleTailFin.Count);
            Destroy(this.gameObject);
        }
    }
}
