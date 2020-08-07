using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpecialMovementData
{
    public int index;
    public int routeType;
    public float velocity;
    public float curve;
    public float moveTime;

    public Vector3 center;
    public float angleRatio;
    public float startAngle;
    public float radius;
    public bool isCounterClockWise;
    public bool isRotateByCircle;
}
