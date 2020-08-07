using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Enemy_Movement_SpecialRoute : MonoBehaviour
/*
 * Routes:
 * 0. x = sin(y)
 * 1. y = sin(x)
 * 2. x = cos(y)
 * 3. y = cos(x)
 * 4. circle
 * 
 */
{
    public int routeType;
    public float velocity;
    public float curve;
    public float moveTime;
    float curMoveTime = 0;

    public Vector3 center;
    public float angleRatio;
    public float startAngle;
    public float radius;
    float curAngle;
    public bool isCounterClockWise;
    public bool isRotateByCircle;

    Enemy_Movement_P2PRoute p2pRouteData;
    Vector3 initPos;
    Dictionary<int, Func<float, Vector3>> routes;
    bool inOpt = false;

    // Start is called before the first frame update
    void Start()
    {
        routes = new Dictionary<int, Func<float, Vector3>>
        {
            { 0, X_sinY },
            { 1, Y_sinX },
            { 2, X_cosY },
            { 3, Y_cosX },
            { 4, circle }
        };
        p2pRouteData = GetComponent<Enemy_Movement_P2PRoute>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (inOpt && routeType != 4)
        {
            transform.position = initPos - routes[routeType](curMoveTime);
            curMoveTime += velocity * Time.fixedDeltaTime;
            if(curMoveTime > velocity * moveTime)
            {
                Destroy(gameObject);
            }
        } 
        else if (inOpt && routeType == 4)
        {
            transform.position = center + radius * routes[routeType](curAngle);
            if (isRotateByCircle)
            {
                if (isCounterClockWise)
                {
                    transform.eulerAngles = new Vector3(0, 0, curAngle + 180);
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, curAngle);
                }
            }
            if (isCounterClockWise)
            {
                curAngle += angleRatio;
            }
            else
            {
                curAngle -= angleRatio;
            }
            curMoveTime += Time.fixedDeltaTime;
            if(curMoveTime > moveTime)
            {
                Destroy(gameObject);
            }
        }
        else if (p2pRouteData.isOnSpecialRoute())
        {
            inOpt = true;
            curAngle = startAngle;
            initPos = transform.position;
        }
    }

    Vector3 X_sinY(float arg)
    {
        return new Vector3(Mathf.Sin(curve * arg), arg, 0);
    }
    Vector3 Y_sinX(float arg)
    {
        return new Vector3(arg, Mathf.Sin(curve * arg), 0);
    }
    Vector3 X_cosY(float arg)
    {
        return new Vector3(Mathf.Cos(curve * arg), arg, 0);
    }
    Vector3 Y_cosX(float arg)
    {
        return new Vector3(arg, Mathf.Cos(curve * arg), 0);
    }

    Vector3 circle(float arg)
    {
        return new Vector3(Mathf.Cos(arg * Mathf.Deg2Rad), Mathf.Sin(arg * Mathf.Deg2Rad), 0);
    }

    public void setByJson(SpecialMovementData data)
    {
        this.routeType = data.routeType;
        this.velocity = data.velocity;
        this.curve = data.curve;
        this.moveTime = data.moveTime;

        this.center = data.center;
        this.angleRatio = data.angleRatio;
        this.startAngle = data.startAngle;
        this.radius = data.radius;
        this.isCounterClockWise = data.isCounterClockWise;
        this.isRotateByCircle = data.isRotateByCircle;
    }
}
