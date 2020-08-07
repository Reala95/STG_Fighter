using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class P2PMovementData
{
    public int index;
    public Vector3 initPos;
    public Vector3[] movePointList;
    public float[] waitTimeList;
    public float[] linearVelocityList;
    public bool rotateWhileWaiting;
    public bool rotateBeforeMoving;
    public bool isLooping;
    public bool hasSpecialRoute;
}
