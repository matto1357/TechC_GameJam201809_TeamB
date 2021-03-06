﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectData
{
    public enum Height
    {
        SHORT,
        MIDLE,
        LONG,
    }
    public Height height;
    public int spornNum;
    [HideInInspector]
    public bool isSporn = false;
}

public class StageData : ScriptableObject {

    public float stageID;
    public int stageRange;
    public List<ObjectData> listObjects = new List<ObjectData>();
    public void OnDisable()
    {
        foreach (ObjectData od in listObjects)
        {
            od.isSporn = false;
        }
    }
}
