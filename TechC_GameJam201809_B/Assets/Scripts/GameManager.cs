using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
	public static GameManager sSingleton { get { return _instance; } }
	static GameManager _instance;

	public List<Transform> tentacleList;

	int mCurrTentacleIndex;

	void Awake()
	{
		if (_instance != null && _instance != this) Destroy(this.gameObject);
		else _instance = this;
	}

	public Transform GetNextTentacle()
	{
		return tentacleList[++mCurrTentacleIndex];
	}
}
