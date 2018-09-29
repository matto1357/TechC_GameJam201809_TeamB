using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCol : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ball")
        {
            Destroy(other.GetComponent<Animator>());
            other.GetComponent<SphereCollider>().isTrigger = false;
            other.GetComponent<Rigidbody>().useGravity = true;
            Debug.Log(other.GetComponentInChildren<MeshRenderer>());
            other.GetComponentInChildren<MeshRenderer>().material.SetColor("_Color", Color.red);
        }
    }
}
