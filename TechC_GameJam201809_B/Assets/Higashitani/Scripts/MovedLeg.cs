using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovedLeg : MonoBehaviour {
    [SerializeField]
    Transform destroyPoint;

    LegInstance li;

	// Use this for initialization
	void Start () {
        li = LegInstance.Instance;
	}
	
	// Update is called once per frame
	void Update () {
        if (GameController.Instance._gameState != GameController.GameState.Game) return;
		foreach(Transform t in li.allLegList)
        {
            AddMove(t.gameObject);
        }
        if(li.allLegList[0].position.x <= destroyPoint.position.x)
        {
            GameObject g = li.allLegList[0].gameObject;
            li.allLegList.RemoveAt(0);

            if (g.tag == "P1_Tentacle") li.octopusLegList.RemoveAt(0);
            else if (g.tag == "P2_Tentacle") li.killerWhaleTailFinList.RemoveAt(0);

            DestroyImmediate(g);
        }

    }

    void AddMove(GameObject g)
    {
        g.transform.position -= new Vector3(GameController.Instance.speed, 0, 0);
    }
}
