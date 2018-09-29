using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectWideScroll : MonoBehaviour {
    
    GameController gc;

    [SerializeField]
    float spornPosX, deletePosX;

    private void Start()
    {
        gc = GameController.Instance;
    }

    // Update is called once per frame
    void Update () {
        if (GameController.Instance._gameState != GameController.GameState.Game) return;
        ObjectScroll();
	}

    public void ObjectScroll()
    {
        this.transform.position -= new Vector3(gc.speed, 0, 0);
        if(transform.position.x <= deletePosX)
        {
            transform.position = new Vector3(spornPosX, transform.position.y, transform.position.z);
        }
    }
}
