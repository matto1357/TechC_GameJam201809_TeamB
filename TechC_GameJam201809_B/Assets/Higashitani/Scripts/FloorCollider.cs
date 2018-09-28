using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCollider : MonoBehaviour {
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ball")
        {
            GameController.Instance.GameOver();
        }
    }
}
