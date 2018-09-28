using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {
    [SerializeField]
    List<GameObject> instanceObjects = new List<GameObject>();
    List<GameObject> fieldsObjects = new List<GameObject>();

    GameController gc;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ObjInstance();
        ObjMove();
	}

    void ObjInstance()
    {
        for (int i = 0; i < gc.sData.listObjects.Count; i++)
        {
            if (gc.sData.listObjects[i].spornNum == gc.legsCount)
            {
                var o = Instantiate(gc.sData.listObjects[i].height);
                fieldsObjects.Add(o);
            }
        }
    }

    void ObjMove()
    {
        foreach(GameObject f in fieldsObjects)
        {
            f.transform.position -= new Vector3(gc.sData.speed, 0, 0);
        }
    }

}
