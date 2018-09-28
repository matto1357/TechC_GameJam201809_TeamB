using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectWideScroll : MonoBehaviour {

    [SerializeField]
    public float speed;

	// Update is called once per frame
	void Update () {
        ObjectScroll();
	}

    public void ObjectScroll()
    {
        this.transform.position -= new Vector3(speed, 0, 0);
    }
}
