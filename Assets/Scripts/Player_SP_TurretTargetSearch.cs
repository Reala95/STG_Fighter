using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player_SP_TurretTargetSearch : MonoBehaviour
{
    public float aimAccuracy;
    
    GameObject target;
    bool haveTarget;

    // Start is called before the first frame update
    void Start()
    {
        setNewTarget();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(target == null)
        {
            setNewTarget();
        }
        else if (haveTarget)
        {
            turnToTarget();
        }
        else
        {
            turnToDefault();
        }
    }

    private void turnToTarget()
    {
        Quaternion q = Quaternion.AngleAxis(getTargetAngle(target) - 90, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, aimAccuracy);
    }

    private void turnToDefault()
    {
        Quaternion q = Quaternion.AngleAxis(0, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, aimAccuracy);
    }

    private float getTargetAngle(GameObject target)
    {
        Vector3 headToTarget = target.transform.position - transform.position;
        return Mathf.Atan2(headToTarget.y, headToTarget.x) * Mathf.Rad2Deg;
    }

    public void setNewTarget()
    {
        GameObject[] targetList = GameObject.FindGameObjectsWithTag("Enemy");
        if (targetList.Length != 0)
        {
            target = targetList.OrderBy(t => (t.transform.position - transform.position).sqrMagnitude).First();
            turnToTarget();
            haveTarget = true;
        }
        else
        {
            Quaternion q = Quaternion.AngleAxis(0, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, aimAccuracy);
            haveTarget = false;
        }
    }
}
