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
            Debug.Log("OnMoving but stopped");
            if (rotateToNextBeforeMove)
            {
                Quaternion q = Quaternion.AngleAxis(moveAngleList[curDestination] + 90, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, q, 1);
            }
            curMoveTime = moveTimeList[curDestination];
            enemy.velocity = getCurVelocity();
        }
        else if (onMove)
        {
            Debug.Log("OnMoving");
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
            Debug.Log("OnWaiting");
            curWaitTime -= Time.fixedDeltaTime;
            if (rotateToNextWhileWaiting)
            {
                rotateToNext();
            } 
            if (curWaitTime <= 0)
            {
                onMove = true;
                onWait = false;
                curDestination++;
                if(curDestination == moveAngleList.Length)
                {
                    Destroy(gameObject);
                }
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
        Quaternion q;
        if (curDestination + 1 == moveAngleList.Length)
        {
            q = Quaternion.AngleAxis(initAngle + 90, Vector3.forward);
        }
        else
        {
            q = Quaternion.AngleAxis(moveAngleList[curDestination + 1] + 90, Vector3.forward);
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, q, waitTimeList[curDestination] - curWaitTime);
    }

}
