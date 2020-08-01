using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2PMovementData
{
    public Vector3 initPos;
    public Vector3[] movePointList;
    public float[] waitTimeList;
    public float[] linearVelocityList;
    public bool rotateWhileWaiting;
    public bool rotateBeforeMoving;
    public bool isLooping;

    public P2PMovementData(Vector3 initPos, Vector3[] movePointList, float[] waitTimeList, float[] linearVelocityList, bool rotateWhileWaiting, bool rotateBeforeMoving, bool isLooping)
    {
        this.initPos = initPos;
        this.movePointList = movePointList;
        this.waitTimeList = waitTimeList;
        this.linearVelocityList = linearVelocityList;
        this.rotateWhileWaiting = rotateWhileWaiting;
        this.rotateBeforeMoving = rotateBeforeMoving;
        this.isLooping = isLooping;
    }
}
