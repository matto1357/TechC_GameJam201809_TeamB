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
		gc = GameController.Instance;
	}
	
	// Update is called once per frame
	void Update () {
        ObjInstance();
        ObjMove(1.0f);
	}

    void ObjInstance()
    {
        for (int i = 0; i < gc.sData.listObjects.Count; i++)
        {
            if (gc.sData.listObjects[i].spornNum == gc.legsCount)
            {
                GameObject gameObject = instanceObjects[(int)(gc.sData.listObjects[i].height)];
                //switch (gc.sData.listObjects[i].height)
                //{
                //    case ObjectData.Height.LONG:
                //        gameObject = instanceObjects[0];
                //        return;
                //    case ObjectData.Height.MIDLE:
                //        gameObject = instanceObjects[1];
                //        return;
                //    case ObjectData.Height.SHORT:
                //        gameObject = instanceObjects[2];
                //        return;
                //}
                var o = Instantiate(gameObject);
                fieldsObjects.Add(o);
            }
        }
    }

    void ObjMove(float a)
    {
        foreach(GameObject f in fieldsObjects)
        {
            f.transform.position -= new Vector3(gc.speed, 0, 0);
        }
    }

}
