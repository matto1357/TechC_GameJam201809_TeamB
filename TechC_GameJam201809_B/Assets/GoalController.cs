using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour {

    [SerializeField]
    string ballName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.name != ballName) return;
        Destroy(other.GetComponent<Rigidbody>());
        GameController.Instance.GameClear();
    }

}
