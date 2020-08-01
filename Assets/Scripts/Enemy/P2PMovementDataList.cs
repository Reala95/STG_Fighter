using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2PMovementDataList
{
    public class P2PMovementData
    {
        public Vector3 initPos;
        public Vector3[] movePointList;
        public float[] waitTimeList;
        public float[] linearVelocityList;
        public bool rotateWhileWaiting;
        public bool rotateBeforeMoving;
        public bool isLooping;
    }

    public P2PMovementData[] list;
}
