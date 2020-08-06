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
 * 
 */
{
    public int routeType;
    public float velocity;
    public float curve;
    public float moveTime;
    float curMoveTime = 0;

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
            { 3, Y_cosX }
    };
        p2pRouteData = GetComponent<Enemy_Movement_P2PRoute>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (inOpt)
        {
            transform.position = initPos - routes[routeType](curMoveTime);
            curMoveTime += velocity * Time.fixedDeltaTime;
            if(curMoveTime > velocity * moveTime)
            {
                Destroy(gameObject);
            }
        }
        else if (p2pRouteData.isOnSpecialRoute())
        {
            inOpt = true;
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
}
