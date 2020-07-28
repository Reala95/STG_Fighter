using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Player_StardustSpecialAbility : MonoBehaviour
{
    public GameObject turretBullet;
    public bool isOverloadActived = false;
    public float turretNormalCD;
    public float turretOverloadCD;
    public float overloadDuration;
    public float spinSpeed;
    GameObject target;
    Common_Bullet turretBulletData;
    float currentTurretNormalCD = 0;
    float currentTurretOverloadCD = 0;
    float currentOverloadDuration = 0;

    // Start is called before the first frame update
    void Start()
    {
        turretBulletData = turretBullet.GetComponent<Common_Bullet>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !isOverloadActived)
        {
            isOverloadActived = true;
            currentOverloadDuration = overloadDuration;
            currentTurretOverloadCD = turretOverloadCD;

        }
        target = GameObject.FindGameObjectsWithTag("Enemy").OrderBy(t => (transform.position - t.transform.position).sqrMagnitude).First();
    }

    private void FixedUpdate()
    {
        if (!isOverloadActived)
        {
            currentTurretNormalCD -= Time.fixedDeltaTime;
            if (currentTurretNormalCD <= 0)
            {
                Fire();
                currentTurretNormalCD = turretNormalCD;
            }
        } 
        else
        {
            currentTurretOverloadCD -= Time.fixedDeltaTime;
            if(currentTurretOverloadCD <= 0)
            {
                OverloadFire();
                currentTurretOverloadCD = turretOverloadCD;
            }
            currentOverloadDuration -= Time.fixedDeltaTime;
            if (currentOverloadDuration <= 0)
            {
                isOverloadActived = false;
            }
        }
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

    private void Fire()
    {
        turretBulletData.shootDegree = getTargetAngle(target);
        turretBullet.transform.position = transform.position;
        Instantiate(turretBullet);
    }

    private void OverloadFire()
    {
        for(int i = 0; i < 5; i++)
        {
            turretBulletData.shootDegree = getTargetAngle(target) - 10 + i * 5;
            turretBullet.transform.position = transform.position;
            Instantiate(turretBullet);
        }
    }
}
