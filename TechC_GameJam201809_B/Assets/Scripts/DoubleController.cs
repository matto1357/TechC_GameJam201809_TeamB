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
		// ----------------------------------------------------------------------
		// ------------------------------ P1 ------------------------------------
		// ----------------------------------------------------------------------

		float horizontalP1 = Input.GetAxis ("HorizontalXBoxP1");
		float verticalP1 = Input.GetAxis ("VerticalXBoxP1");
		float horizontalDpadP1 = Input.GetAxis ("HorizontalDPadXBoxP1");
		float verticalDpadP1 = Input.GetAxis ("VerticalDpadXBoxP1");

		if (mIsP1Hit) 
		{
			if ( (verticalDpadP1 > 0　|| Input.GetKey(KeyCode.UpArrow)) && (Input.GetKeyDown (KeyCode.Joystick1Button1) || Input.GetKeyDown (KeyCode.Space)) ) 
			{
				// 上　+　Aボタン
				mIsP1Hit = false;
				mJumpPress = JumpPress.UP;
				Debug.Log ("up A button");
			}
			else if ( (verticalDpadP1 < 0 || Input.GetKey(KeyCode.DownArrow)) && (Input.GetKeyDown (KeyCode.Joystick1Button1) || Input.GetKeyDown (KeyCode.Space)) ) 
			{
				// 下　+　Aボタン
				mIsP1Hit = false;
				mJumpPress = JumpPress.DOWN;
				Debug.Log ("down A button");
			}
			else if (Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.Space)) 
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
			if ( (verticalDpadP2 > 0　|| Input.GetKey(KeyCode.UpArrow)) && (Input.GetKeyDown (KeyCode.Joystick2Button0) || Input.GetKeyDown (KeyCode.KeypadEnter)) )
			{
				// 上　+　Aボタン
				mIsP2Hit = false;
				mJumpPress = JumpPress.UP;
				Debug.Log ("up A button");
			}
			else if ( (verticalDpadP2 < 0 || Input.GetKey(KeyCode.DownArrow)) &&  (Input.GetKeyDown (KeyCode.Joystick2Button0) || Input.GetKeyDown (KeyCode.KeypadEnter)) )
			{
				// 下　+　Aボタン
				mIsP2Hit = false;
				mJumpPress = JumpPress.DOWN;
				Debug.Log ("down A button");
			}
			else if (Input.GetKeyDown(KeyCode.Joystick2Button0) || Input.GetKeyDown(KeyCode.KeypadEnter)) 
			{
				mIsP2Hit = false;
				mJumpPress = JumpPress.NORMAL;
				Debug.Log ("P2 Button A");
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
