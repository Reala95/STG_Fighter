using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Rendering;

public class Enemy_Movement_P2PRoute : MonoBehaviour
/* 
 * Enemy movement ai script:
 * This script can set up straight movment routes of an object from point to point.
 * 
*/
{
    public Vector3 initPos; // Initial postion of the gameObject
    // The following arrays must set to same lenght, because they are sharing a same index number while working
    public Vector3[] movePointList; // List of destination points 
    public float[] waitTimeList; // List of time need to wait on destination
    public float[] linearVelocityList; // List of linear velocity of the gameObject when move to destination
    public int specialRouteType;
    public bool rotateWhileWaiting; // Bool to set the gameObecjt will rotate toward to next destination while in waiting
    public bool rotateBeforeMoving; // Bool to set the gameObject to instantly rotate toward to next destination when they start to move
    public bool isLooping; // Bool to set the gameObject will destroyed or head back to the first destination
    public bool hasSpecialRoute; // Bool to start runing special route, can't set to true will the route is in looping;

    Enemy_Movement_SpecialRoute specialRouteData;
    int curRoute = 0;
    int totalRoute;
    Vector3 curPos;
    Quaternion curRot;
    Quaternion targetRot;
    float curMoveTime = 0;
    float curWaitTime = 0;
    bool onMove = true;
    bool onWait = false;
    bool onSpecialRoute = false;
    

    // Start is called before the first frame update
    void Start()
    {
        transform.position = initPos;
        curPos = initPos;
        totalRoute = movePointList.Length;
        if (rotateBeforeMoving || rotateWhileWaiting)
        {
            Quaternion q = Quaternion.AngleAxis(getRotateAngle(movePointList[curRoute]) + 90, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, 1);
        }
        if (hasSpecialRoute)
        {
            specialRouteData = GetComponent<Enemy_Movement_SpecialRoute>();
            specialRouteData.routeType = specialRouteType;
        }
        if(waitTimeList.Length != totalRoute || linearVelocityList.Length != totalRoute)
        {
            Debug.LogError(gameObject.name + ": route number not match, this gameObject has been deleted.");
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (onMove)
        {
            curMoveTime += Time.fixedDeltaTime;
            transform.position = Vector3.MoveTowards(curPos, movePointList[curRoute], linearVelocityList[curRoute] * curMoveTime);
            if(transform.position == movePointList[curRoute])
            {
                onMove = false;
                onWait = true;
                curPos = transform.position;
                curRot = transform.rotation;
                targetRot = Quaternion.AngleAxis(getRotateAngle(movePointList[getNextRouteNumber()]) + 90, Vector3.forward);
                curWaitTime = 0;


            }
        }
        else if (onWait)
        {
            curWaitTime += Time.fixedDeltaTime;
            if (rotateWhileWaiting)
            {
                if(waitTimeList[curRoute] == 0)
                {
                    transform.rotation = Quaternion.Slerp(curRot, targetRot, 1);
                }
                else
                {
                    transform.rotation = Quaternion.Slerp(curRot, targetRot, curWaitTime / waitTimeList[curRoute]);
                }
                
            }
            if(curWaitTime >= waitTimeList[curRoute])
            {
                onMove = true;
                onWait = false;
                curMoveTime = 0;
                if (rotateBeforeMoving)
                {
                    transform.rotation = Quaternion.Slerp(curRot, targetRot, 1);
                }
                if (!isLooping && curRoute + 1 == totalRoute)
                {
                    if (hasSpecialRoute)
                    {
                        onSpecialRoute = true;
                        onMove = false;
                    }
                    else
                    {
                        Destroy(gameObject);
                    }
                }
                curRoute = getNextRouteNumber();
            }
        }
    }

    private float getRotateAngle(Vector3 destination)
    {
        Vector3 headToTarget = destination - transform.position;
        return Mathf.Atan2(headToTarget.y, headToTarget.x) * Mathf.Rad2Deg;
    }

    private int getNextRouteNumber()
    {
        return (curRoute + 1) % totalRoute;
    }

    public void setUpByJson(P2PMovementData data)
    {
        initPos = data.initPos;
        movePointList = data.movePointList;
        waitTimeList = data.waitTimeList;
        linearVelocityList = data.linearVelocityList;
        specialRouteType = data.specialRouteType;
        rotateWhileWaiting = data.rotateWhileWaiting;
        rotateBeforeMoving = data.rotateBeforeMoving;
        isLooping = data.isLooping;
        hasSpecialRoute = data.hasSpecialRoute;
    }

    public int getCurRoute()
    {
        return curRoute;
    }

    public bool isOnMove()
    {
        return onMove;
    }
    
    public bool isOnWait()
    {
        return onWait;
    }

    public bool isOnSpecialRoute()
    {
        return onSpecialRoute;
    }
}
