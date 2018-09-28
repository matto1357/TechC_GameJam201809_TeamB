using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObj : MonoBehaviour {

    GameObject gameObject;
    GameController gameController;

	// Use this for initialization
	void Start () {
        gameObject = GameObject.Find("Manager");
        gameController = gameObject.GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position += new Vector3(/*GameControllerのspeed変数*/-0.05f,0,0);
	}
}
