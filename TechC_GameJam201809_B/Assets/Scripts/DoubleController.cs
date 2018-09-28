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

	Vector3 mInitialPos, mEndPos;
	ParabolaController mParabolaController;

	void Start()
	{
		mRigidbody = gameObject.GetComponent<Rigidbody> ();
		mParabolaController = GetComponent<ParabolaController> ();
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

		// 右に行く
		if (horizontalP1 > 0 || horizontalDpadP1 > 0) 
		{
			Debug.Log ("P1 右");
		}
		// 左に行く
		else if (horizontalP1 < 0 ||  horizontalDpadP1 < 0) 
		{
			Debug.Log ("P1 左");
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
		float verticalP2 = Input.GetAxis ("VerticalXBoxP2");
		float horizontalDpadP2 = Input.GetAxis ("HorizontalDPadXBoxP2");
		float verticalDpadP2 = Input.GetAxis ("VerticalDpadXBoxP2");

		// 右に行く
		if (horizontalP2 > 0 || horizontalDpadP2 > 0) 
		{
			Debug.Log ("P2 右");
		}
		// 左に行く
		else if (horizontalP2 < 0 ||  horizontalDpadP2 < 0) 
		{
			Debug.Log ("P2 左");
		}

		// 下に行く
		if (verticalP2 > 0 || verticalDpadP2 < 0) 
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
			mParabolaController.SetNewParabola ();
			mParabolaController.FollowParabola ();
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
		}
	}

	void FixedUpdate()
	{
		if (mIsHit) 
		{
//			MathParabola.Parabola(
//			mRigidbody.AddForce (new Vector3(0.5f, 0.5f, 0) * 800.0f);
//			mIsHit = false;
		}
	}

	void OnTriggerStay(Collider other)
	{
//		if (other.tag == "P1_Tentacle") 
//		{
//			if (Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.Space)) 
//			{
//				mIsHit = true;
//				mInitialPos = transform.position;					
//				mEndPos = GameManager.sSingleton.GetNextTentacle ().position;
//				Debug.Log ("P1 Button A");
//			}
//			else if (Input.GetKeyDown(KeyCode.Joystick1Button2)) 
//			{
//				mIsHit = true;
//				Debug.Log ("P1 Button B");
//			}
//		}
//		else if (other.tag == "P2_Tentacle") 
//		{
//			if (Input.GetKeyDown(KeyCode.Joystick1Button1)) 
//			{
//				mIsHit = true;
//				mInitialPos = transform.position;					
//				Debug.Log ("P2 Button A");
//			}
//			else if (Input.GetKeyDown(KeyCode.Joystick1Button2)) 
//			{
//				mIsHit = true;
//				Debug.Log ("P2 Button B");
//			}
//		}
////		Debug.Log ("AAAA");
	}
}
