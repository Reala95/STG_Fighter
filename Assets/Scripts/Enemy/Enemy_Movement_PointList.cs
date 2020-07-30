using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy_Movement_PointList : MonoBehaviour
/*
 * Enemy movement route ai script: (still need to improve)
 * This script is to set the straight movement route by angles with specfic time, after a route is finish, the gameObject will wait before
 * the next route.
 * 
 */
{
    public Vector3 initPos; // Initial position
    public float initAngle; // Initial rotote angle
    public float[] moveAngleList; // The movement angle list
    public float[] moveTimeList; // The movement time list
    float curMoveTime;
    public float[] waitTimeList; // The wait time list 
    float curWaitTime = 0;
    public float linearVelocity; // The linear velocity of the gameObject
    // Both booleans below can turn to false if the gameObject doesn't need to rotate or other scripts are controling gameObject's roation.
    public bool rotateToNextBeforeMove; // When true, the gameObject will instant rotate to the next angle
    public bool rotateToNextWhileWaiting; // When true, the gameObject will slowly rotate to the next angle while in waiting
    public bool isRouteLoop; // When true, the gameObject will loop back to the first destniation 


    Rigidbody2D enemy;
    int curDestination = 0;
    bool onMove = false;
    bool onWait = false;

    // Start is called before the first frame update
    void Start()
    {
        checkArraysConflict();
        enemy = GetComponent<Rigidbody2D>();
        Quaternion q = Quaternion.AngleAxis(initAngle + 90, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, 1);
        onMove = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(onMove && enemy.velocity == Vector2.zero)
        {
            if (rotateToNextBeforeMove || waitTimeList[curDestination] == 0)
            {
                Quaternion q = Quaternion.AngleAxis(moveAngleList[curDestination] + 90, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, q, 1);
            }
            curMoveTime = moveTimeList[curDestination];
            enemy.velocity = getCurVelocity();
        }
        else if (onMove)
        {
            curMoveTime -= Time.fixedDeltaTime;
            if(curMoveTime <= 0)
            {
                onMove = false;
                onWait = true;
                enemy.velocity = Vector2.zero;
                curWaitTime = waitTimeList[curDestination];
            }
        }
        else if (onWait)
        {
            curWaitTime -= Time.fixedDeltaTime;
            if (rotateToNextWhileWaiting && waitTimeList[curDestination] != 0)
            {
                rotateToNext();
            } 
            if (curWaitTime <= 0)
            {
                curDestination++;
                if (isRouteLoop && curDestination == moveAngleList.Length)
                {
                    curDestination = 0;
                }
                else if(curDestination == moveAngleList.Length)
                {
                    Destroy(gameObject);
                }
                onMove = true;
                onWait = false;                               
            }
        }
    }

    Vector2 getCurVelocity()
    {
        return new Vector2(
            linearVelocity * Mathf.Cos(moveAngleList[curDestination] * Mathf.Deg2Rad),
            linearVelocity * Mathf.Sin(moveAngleList[curDestination] * Mathf.Deg2Rad)
            );
    }

    void rotateToNext()
    {
        Quaternion from = Quaternion.AngleAxis(getCurAngle() + 90, Vector3.forward);
        Quaternion to = Quaternion.AngleAxis(moveAngleList[curDestination + 1] + 90, Vector3.forward);
        transform.rotation = Quaternion.Slerp(
            from, 
            to,
            1 - Mathf.Max(0, curWaitTime) / waitTimeList[curDestination] 
            );
    }

    float getCurAngle()
    {
        if(curDestination - 1 == -1)
        {
            return initAngle;
        }
        else
        {
            return moveAngleList[curDestination];
        }
    }

    void checkArraysConflict()
    {
        if (moveAngleList.Length != waitTimeList.Length || waitTimeList.Length != moveTimeList.Length)
        {
            Debug.LogError(gameObject.name + ": MovePointList Conflicted, the object has been deleted");
            Destroy(gameObject);
        }
        else if (moveAngleList.Length == 0)
        {
            Debug.LogError(gameObject.name + ": MovePointList Conflicted, the object has been deleted");
            Destroy(gameObject);
        }
        
    }
}
