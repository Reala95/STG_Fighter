using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSS_Stage1_BigEaterBodyPart : MonoBehaviour
{
    public Vector3 startPos, endPos;
    public float velocity;
    
    float moveTime = 0; 
    bool onMove = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (onMove)
        {
            moveTime += Time.fixedDeltaTime;
            transform.position = Vector3.MoveTowards(startPos, endPos, velocity * moveTime);
            if(transform.position == endPos)
            {
                onMove = false;
            }
        }
    }

    public void setRoute (Vector3 start, Vector3 end)
    {
        startPos = start;
        endPos = end;
        transform.position = start;
        moveTime = 0;
        Quaternion q = Quaternion.AngleAxis(getRouteAngle() + 90, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, 1);
        onMove = true;
    }

    public void setOnMove(bool onMove) 
    {
        this.onMove = onMove;
    }

    private float getRouteAngle()
    {
        Vector3 v = endPos - startPos;
        return Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
    }
}
