using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy_Movement_PointList : MonoBehaviour
// Script of enemy to let them move from point to point
{
    public Vector3 initPos;
    public float initAngle;
    public float[] moveAngleList;
    public float[] moveTimeList;
    float curMoveTime;
    public float[] waitTimeList;
    float curWaitTime = 0;
    public float linearVelocity;
    public bool rotateToNextBeforeMove;
    public bool rotateToNextWhileWaiting;


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
                if(curDestination == moveAngleList.Length)
                {
                    Destroy(gameObject);
                }
                onMove = true;
                onWait = false;                               
            }
        }
        //Debug.Log(enemy.velocity.x + ", " + enemy.velocity.y);
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
