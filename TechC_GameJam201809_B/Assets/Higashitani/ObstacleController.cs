using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {
    [SerializeField]
    List<GameObject> Objects = new List<GameObject>();
    [SerializeField]
    StageData sData;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        for(int i = 0; i < sData.listObjects.Count; i++)
        {
            //if (sData.listObjects[i].spornNum)
            //{

            //}
        }
	}
}
