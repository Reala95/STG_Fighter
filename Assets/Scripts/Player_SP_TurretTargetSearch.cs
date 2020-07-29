using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player_SP_TurretTargetSearch : MonoBehaviour
{
    Player_SP_TurretWeaponControl turretWeapon;
    GameObject target;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindGameObjectsWithTag("Enemy").OrderBy(t => (t.transform.position - transform.position).sqrMagnitude).First();
        Quaternion q = Quaternion.AngleAxis(getTargetAngle(target) - 90, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, 0.05f);
    }

    private float getTargetAngle(GameObject target)
    {
        if (target != null)
        {
            Vector3 headToTarget = target.transform.position - transform.position;
            return Mathf.Atan2(headToTarget.y, headToTarget.x) * Mathf.Rad2Deg;
        }
        else
        {
            return 90;
        }
    }
}
