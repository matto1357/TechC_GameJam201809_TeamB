using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActionPower
{
    Height,
    Midle,
    Low,
}

public class BallController : MonoBehaviour {
    Animator animator;
    [SerializeField]
    bool isInArea1P = false;
    [SerializeField]
    bool isInArea2P = false;

    [SerializeField]
    bool iskeyDown = false;

    float timer;
    bool isStart = false;

    //Inspectorで好きなボタンに変えられるようにする
    [SerializeField]
    public KeyCode key1A;  // 1Pのアクションボタン
    [SerializeField]
    public KeyCode key1U;  // 1Pの↑ボタン
    [SerializeField]
    public KeyCode key1D;  // 1Pの↓ボタン
    [SerializeField]
    public KeyCode key2A;  // 2Pのアクションボタン
    [SerializeField]
    public KeyCode key2U;  // 2Pの↑ボタン
    [SerializeField]
    public KeyCode key2D;  // 2Pの↓ボタン

    void Start () {
        animator = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
        if (!animator) return;
        if (GameController.Instance._gameState != GameController.GameState.Game) return;
        if (!isStart)
        {
            timer += Time.deltaTime;
            if (timer > 4.8f)
            {
                animator.SetBool("Midle", true);
                isStart = true;
            }
        }

        if (iskeyDown) return;

        if(Input.GetKeyDown(key1A) && isInArea1P)
        {
            if (Input.GetKey(key1U))
            {
                MoveLeg(0, ActionPower.Height);
                Debug.Log("q");
            }
            else if (Input.GetKey(key1D))
            {
                MoveLeg(0, ActionPower.Low);
                Debug.Log("a");
            }
            else
            {
                MoveLeg(0, ActionPower.Midle);
                Debug.Log("s");
            }
        }

        if (Input.GetKeyDown(key2A) && isInArea2P)
        {
            if (Input.GetKey(key2U))
            {
                MoveLeg(1, ActionPower.Height);
                Debug.Log("uarrow");
            }
            else if (Input.GetKey(key2D))
            {
                MoveLeg(1, ActionPower.Low);
                Debug.Log("darrow");
            }
            else
            {
                MoveLeg(1, ActionPower.Midle);
                Debug.Log("rarrow");
            }
        }
    }

    public void MoveLeg(int controllerID, ActionPower ap)
    {
        GameController.Instance.legsCount++;
        List<GameObject> targetObj = new List<GameObject>();
        switch (controllerID)
        {
            //たこ
            case 0:
                targetObj = LegInstance.Instance.octopusLegList;
                break;
            //シャチ
            case 1:
                targetObj = LegInstance.Instance.killerWhaleTailFinList;
                break;
        }

        for (int i = 0; i < targetObj.Count; i++)
        {
            Animator anim = targetObj[i].GetComponent<Animator>();
            //動き
            switch (ap)
            {
                case ActionPower.Height:
                    anim.SetTrigger("Up");
                    animator.SetBool("Height", true);
                    iskeyDown = true;
                    continue;

                case ActionPower.Midle:
                    anim.SetTrigger("Srow");
                    animator.SetBool("Midle", true);
                    iskeyDown = true;
                    continue;

                case ActionPower.Low:
                    anim.SetTrigger("Srow");
                    animator.SetBool("Short", true);
                    iskeyDown = true;
                    continue;
            }
        }
    }
    
    public void ResetTrigger()
    {
        if (!animator) return;
        animator.SetBool("Short", false);
        animator.SetBool("Midle", false);
        animator.SetBool("Height", false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("p1");
        if (other.tag == "P1_Tentacle")
        {
            isInArea1P = true;
        }
        else if (other.tag == "P2_Tentacle")
        {
            isInArea2P = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "P1_Tentacle")
        {
            isInArea1P = false;
            iskeyDown = false;
            ResetTrigger();
        }
        else if(other.tag == "P2_Tentacle")
        {
            isInArea2P = false;
            iskeyDown = false;
            ResetTrigger();
        }
    }

}
