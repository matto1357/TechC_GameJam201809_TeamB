using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleController : MonoBehaviour
{
    public float upJump = 10.0f;
    public float normalJump = 5.0f;
    public float downJump = 2.5f;

    bool mIsP1Hit, mIsP2Hit;

    enum JumpPress
    {
        NONE = 0,
        NORMAL,
        UP,
        DOWN
    }
    JumpPress mJumpPress = JumpPress.NONE;

    Rigidbody mRigidbody;

    void Start()
    {
        mRigidbody = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Mathf.Abs(LegInstance.Instance.allLegList[0].position.x - transform.position.x) <= 0.5f) mRigidbody.useGravity = true;
        // ----------------------------------------------------------------------
        // ------------------------------ P1 ------------------------------------
        // ----------------------------------------------------------------------

        float horizontalP1 = Input.GetAxis("HorizontalXBoxP1");
        float verticalP1 = Input.GetAxis("VerticalXBoxP1");
        float horizontalDpadP1 = Input.GetAxis("HorizontalDPadXBoxP1");
        float verticalDpadP1 = Input.GetAxis("VerticalDpadXBoxP1");

        if (mIsP1Hit)
        {
            if ((verticalDpadP1 > 0 || Input.GetKey(KeyCode.UpArrow)) && (Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(GetKey.Instance.key1U)))
            {
                // 上　+　Aボタン
                mIsP1Hit = false;
                mJumpPress = JumpPress.UP;
                Debug.Log("up A button");
            }
            else if ((verticalDpadP1 < 0 || Input.GetKey(KeyCode.DownArrow)) && (Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(GetKey.Instance.key1D)))
            {
                // 下　+　Aボタン
                mIsP1Hit = false;
                mJumpPress = JumpPress.DOWN;
                Debug.Log("down A button");
            }
            else if (Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(GetKey.Instance.key1A))
            {
                // Aボタン
                mIsP1Hit = false;
                mJumpPress = JumpPress.NORMAL;
                Debug.Log("P1 Button A");
            }
        }

        // ----------------------------------------------------------------------
        // ------------------------------ P2 ------------------------------------
        // ----------------------------------------------------------------------

        float horizontalP2 = Input.GetAxis("HorizontalXBoxP2");
        float verticalP2 = Input.GetAxis("VerticalXBoxP2");
        float horizontalDpadP2 = Input.GetAxis("HorizontalDPadXBoxP2");
        float verticalDpadP2 = Input.GetAxis("VerticalDpadXBoxP2");

        if (mIsP2Hit)
        {
            if ((verticalDpadP2 > 0 || Input.GetKey(KeyCode.UpArrow)) && (Input.GetKeyDown(KeyCode.Joystick2Button0) || Input.GetKeyDown(GetKey.Instance.key2U)))
            {
                // 上　+　Aボタン
                mIsP2Hit = false;
                mJumpPress = JumpPress.UP;
                Debug.Log("up A button");
            }
            else if ((verticalDpadP2 < 0 || Input.GetKey(KeyCode.DownArrow)) && (Input.GetKeyDown(KeyCode.Joystick2Button0) || Input.GetKeyDown(GetKey.Instance.key2D)))
            {
                // 下　+　Aボタン
                mIsP2Hit = false;
                mJumpPress = JumpPress.DOWN;
                Debug.Log("down A button");
            }
            else if (Input.GetKeyDown(KeyCode.Joystick2Button0) || Input.GetKeyDown(GetKey.Instance.key2A))
            {
                mIsP2Hit = false;
                mJumpPress = JumpPress.NORMAL;
                Debug.Log("P2 Button A");
            }
        }
    }

    void FixedUpdate()
    {
        if (mJumpPress != JumpPress.NONE)
        {
            float jumpVal = normalJump;

            if (mJumpPress == JumpPress.UP) jumpVal = upJump;
            else if (mJumpPress == JumpPress.DOWN) jumpVal = downJump;

            mRigidbody.AddForce(new Vector3(0, jumpVal, 0), ForceMode.Impulse);
            mJumpPress = JumpPress.NONE;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "P1_Tentacle") mIsP1Hit = true;
        else if (other.tag == "P2_Tentacle") mIsP2Hit = true;
    }
}