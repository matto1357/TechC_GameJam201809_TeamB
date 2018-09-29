using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegInstance : SingletonMonoBehaviour<LegInstance> {
    [SerializeField]
    private GameObject octopus;//たこ足
    [SerializeField]
    private GameObject killerWhale;//シャチ尾びれ

    [SerializeField]
    private GameObject octopusText;//たこ足のためのtext
    [SerializeField]
    private GameObject killerWhaleText;//シャチ尾びれのためのtext

    public List<GameObject> octopusLegList;
    public List<GameObject> killerWhaleTailFinList;
    public List<Transform> allLegList;

    [SerializeField]
    Transform spornPoint;

    // 直近に生成した足
    Transform nearObj;

    [SerializeField]
    float interval = 10.0f;

    void Start () {
        nearObj = InstanceLeg();
	}
	
	// Update is called once per frame
	void Update () {
		if(Mathf.Abs(spornPoint.position.x - nearObj.position.x) >= interval)
        {
            Debug.Log(spornPoint.position.x - nearObj.position.x);
            InstanceLeg();
        }
	}

    Transform InstanceLeg()
    {
        int value = Random.Range(0, 2);
        GameObject instanceObjTyp = null;
        if (value == 0) instanceObjTyp = octopus;
        else instanceObjTyp = killerWhale;

        GameObject gameObject = Instantiate(instanceObjTyp, spornPoint.position, Quaternion.Euler(0,90,0));

        nearObj = gameObject.transform;
        allLegList.Add(gameObject.transform);

        if (value == 0) octopusLegList.Add(gameObject);
        else killerWhaleTailFinList.Add(gameObject);

        return gameObject.GetComponent<Transform>();
    }
}
