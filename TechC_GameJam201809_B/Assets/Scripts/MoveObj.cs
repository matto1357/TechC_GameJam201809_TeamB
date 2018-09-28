using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObj : MonoBehaviour {
    
    [SerializeField]
    private GameController gameController;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position += new Vector3(gameController.speed / -60f, 0, 0);
	}
}
