using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleController : MonoBehaviour 
{
	Rigidbody mRigidbody;
	float mMovingTime;
	bool mIsHit = false;
    [SerializeField]
    private LegActionScript legScript;
	public float upJump = 10.0f;
	public float normalJump = 5.0f;
	public float downJump = 2.5f;

	bool mIsP1Hit, mIsP2Hit;

    [SerializeField] public KeyCode Joystick1upArrow;
    [SerializeField] public KeyCode Joystick1DownArrow;
    [SerializeField] public KeyCode Joystick1Button1;
    [SerializeField] public KeyCode Joystick1Space;
    [SerializeField] public KeyCode Joystick2upArrow;
    [SerializeField] public KeyCode Joystick2DownArrow;
    [SerializeField] public KeyCode Joystick2Button0;
    [SerializeField] public KeyCode Joystick2KeypadEnter;


    //キーボードをInspectorで好きなボタンに変えられるようにする
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

    enum JumpPress
	{
		NONE = 0,
		NORMAL,
		UP,
		DOWN
	}
	JumpPress mJumpPress = JumpPress.NONE;

	//Rigidbody mRigidbody;

	void Start()
	{
		mRigidbody = gameObject.GetComponent<Rigidbody> ();
		//mParabolaController = GetComponent<ParabolaController> ();
        legScript = GetComponent<LegActionScript>();
	}

	void Update () 
	{
        Comand();
		// ----------------------------------------------------------------------
		// ------------------------------ P1 ------------------------------------
		// ----------------------------------------------------------------------
        
		float horizontalP1 = Input.GetAxis ("HorizontalXBoxP1");
		float verticalP1 = Input.GetAxis ("VerticalXBoxP1");
		float horizontalDpadP1 = Input.GetAxis ("HorizontalDPadXBoxP1");
		float verticalDpadP1 = Input.GetAxis ("VerticalDpadXBoxP1");

		if (mIsP1Hit) 
		{
			if ( (verticalDpadP1 > 0　|| Input.GetKey(Joystick1upArrow)) && (Input.GetKeyDown (Joystick1Button1) || Input.GetKeyDown (Joystick1Space)) ) 
			{
				// 上　+　Aボタン
				mIsP1Hit = false;
				mJumpPress = JumpPress.UP;
				Debug.Log ("up A button");
			}
			else if ( (verticalDpadP1 < 0 || Input.GetKey(Joystick1DownArrow)) && (Input.GetKeyDown (Joystick1Button1) || Input.GetKeyDown (Joystick1Space)) ) 
			{
				// 下　+　Aボタン
				mIsP1Hit = false;
				mJumpPress = JumpPress.DOWN;
				Debug.Log ("down A button");
			}
			else if (Input.GetKeyDown(Joystick1Button1) || Input.GetKeyDown(Joystick1Space)) 
			{
				// Aボタン
				mIsP1Hit = false;
				mJumpPress = JumpPress.NORMAL;
				Debug.Log ("P1 Button A");
			}
		}
        
		// 下に行く
		if (verticalP1 > 0 || verticalDpadP1 < 0) 
		{
			Debug.Log ("P1 下");
		}
		//　上に行く
		else if (verticalP1 < 0 || verticalDpadP1 > 0) 
		{
			Debug.Log ("P1 上");
		}

        if (Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            Debug.Log("P1 Button A");
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            Debug.Log("P1 Button B");
            legScript.MoveLeg(0);
        }

        // ----------------------------------------------------------------------
        // ------------------------------ P2 ------------------------------------
        // ----------------------------------------------------------------------

        float horizontalP2 = Input.GetAxis ("HorizontalXBoxP2");
		// ----------------------------------------------------------------------
		// ------------------------------ P2 ------------------------------------
		// ----------------------------------------------------------------------

		//float horizontalP2 = Input.GetAxis ("HorizontalXBoxP2");
		float verticalP2 = Input.GetAxis ("VerticalXBoxP2");
		float horizontalDpadP2 = Input.GetAxis ("HorizontalDPadXBoxP2");
		float verticalDpadP2 = Input.GetAxis ("VerticalDpadXBoxP2");

		if (mIsP2Hit) 
		{
			Debug.Log ("P2 下");
		}
		//　上に行く
		else if (verticalP2 < 0 || verticalDpadP2 > 0) 
		{
			Debug.Log ("P2 上");
		}

        if (Input.GetKeyDown(KeyCode.Joystick2Button1))
        {
            Debug.Log("P2 Button 1");
        }
        else if (Input.GetKeyDown(KeyCode.Joystick2Button2))
        {
            Debug.Log("P2 Button 2");
            legScript.MoveLeg(1);
        }

        if (Input.GetKeyDown (KeyCode.Space)) 
		{
			//mParabolaController.SetNewParabola ();
			//mParabolaController.FollowParabola ();
		}
        
		if (mIsHit) 
		{
//			Debug.Log ("AAA");
//
//			mMovingTime += Time.deltaTime;
//			mMovingTime = mMovingTime % 3.0f;
//
//			transform.position = MathParabola.Parabola (mInitialPos, transform.right * 1f, 4f, mMovingTime / 2.0f);
//			Debug.Log (mMovingTime / 3.0f);
//
//			mIsHit = false;
				//			mRigidbody.AddForce (new Vector3(0.5f, 0.5f, 0) * 800.0f);
				//			mIsHit = false;
			if ( (verticalDpadP2 > 0　|| Input.GetKey(Joystick2upArrow)) && (Input.GetKeyDown (Joystick2Button0) || Input.GetKeyDown (Joystick2KeypadEnter)) )
			{
				// 上　+　Aボタン
				mIsP2Hit = false;
				mJumpPress = JumpPress.UP;
				Debug.Log ("up A button");
			}
			else if ( (verticalDpadP2 < 0 || Input.GetKey(Joystick2DownArrow)) &&  (Input.GetKeyDown (Joystick2Button0) || Input.GetKeyDown (Joystick2KeypadEnter)) )
			{
				// 下　+　Aボタン
				mIsP2Hit = false;
				mJumpPress = JumpPress.DOWN;
				Debug.Log ("down A button");
			}
			else if (Input.GetKeyDown(Joystick2Button0) || Input.GetKeyDown(Joystick2KeypadEnter)) 
			{
				mIsP2Hit = false;
				mJumpPress = JumpPress.NORMAL;
				Debug.Log ("P2 Button A");
			}
            
		}
        
	}
    void Comand()
    {

        if (mIsP1Hit)
        {
            //各コマンドボタンの処理
            if (Input.GetKeyDown(key1A))
            {
                // Aボタン
                mIsP1Hit = false;
                mJumpPress = JumpPress.NORMAL;
                Debug.Log("P1 Button A");
            }

            if (Input.GetKey(key1U) && Input.GetKeyDown(key1A))
            {

                // 上　+　Aボタン
                mIsP1Hit = false;
                mJumpPress = JumpPress.UP;
                Debug.Log("key1U!");
            }

            if (Input.GetKey(key1D) && Input.GetKeyDown(key1A))
            {

                // 下　+　Aボタン
                mIsP1Hit = false;
                mJumpPress = JumpPress.DOWN;
                Debug.Log("key1D!");
            }

            if (Input.GetKeyDown(key2A))
            {
                mIsP2Hit = false;
                mJumpPress = JumpPress.NORMAL;
                Debug.Log("key2A!");
            }

            if (Input.GetKey(key2U) && Input.GetKeyDown(key2A))
            {
                // 上　+　Aボタン
                mIsP2Hit = false;
                mJumpPress = JumpPress.UP;
                Debug.Log("key2U!");
            }

            if (Input.GetKey(key2D) && Input.GetKeyDown(key2A))
            {

                // 下　+　Aボタン
                mIsP2Hit = false;
                mJumpPress = JumpPress.DOWN;
                Debug.Log("key2D!");
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
