using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {
    [SerializeField]
    List<GameObject> instanceObjects = new List<GameObject>();
    List<GameObject> fieldsObjects = new List<GameObject>();

    GameController gc;

    Transform spornPoint;

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
                if (gc.sData.listObjects[i].isSporn) return;
                GameObject gameObject = instanceObjects[(int)(gc.sData.listObjects[i].height)];
                var o = Instantiate(gameObject);
                fieldsObjects.Add(o);
                gc.sData.listObjects[i].isSporn = true;
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
