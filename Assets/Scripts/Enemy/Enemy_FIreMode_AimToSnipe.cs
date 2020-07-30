﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_FIreMode_AimToSnipe : MonoBehaviour
/* 
 * Enmey firemode ai script:
 * When using this script, the enemy with rotate toward to player, and fire by specific rate. (see attribute below)
 * 
 * PS. Make sure to disable the rotation action in other movement script, this script can't use with other firemode scripts. 
*/
{
    public GameObject bullet; // Make sure to asign "Enemy_FireMode_AimToSnipeBulletSet" to the bullet prefab
    public float aimAccuracy; // Accuracy when lock on moving target (Range: 0 ~ 1)
    public float firstShotWaitTime; // Wait time before the fire shot
    public float reloadTime; // Interval between fire phase
    float curReloadTime = 0;
    public int bulletClip; // The number of firing whitin a fire phase
    int curBulletClip = 0;
    public int clipAmount; // The number of fire phase (inifinite clip when set to -1)
    public float fireInterval; // Fire interval within a fire phase (If clip is 0, then set this to 0)
    float curFireInterval = 0;

    GameObject targetPlayer;
    bool isReloading = false;
    bool isFiring = false;

    // Start is called before the first frame update
    void Start()
    {
        curReloadTime = firstShotWaitTime;
        isReloading = true;
    }

    // Update is called once per frame
    void Update()
    {
        targetPlayer = GameObject.FindGameObjectWithTag("Player");
        Quaternion q = Quaternion.AngleAxis(getTargetAngle(targetPlayer) + 90, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, aimAccuracy);
    }

    private void FixedUpdate()
    {
        if (isReloading)
        {
            curReloadTime -= Time.fixedDeltaTime;
            if(curReloadTime <= 0)
            {
                curFireInterval = 0;
                curBulletClip = bulletClip;
                isReloading = false;
                isFiring = true;
            }
        }
        else if (isFiring)
        {
            curFireInterval -= Time.fixedDeltaTime;
            if(curFireInterval <= 0)
            {
                Fire();
                curFireInterval = fireInterval;
                curBulletClip--;
            }
            if(curBulletClip == 0)
            {
                curReloadTime = reloadTime;
                isReloading = true;
                isFiring = false;
            }
        }
    }

    private float getTargetAngle(GameObject target)
    {
        Vector3 headToTarget = target.transform.position - transform.position;
        return Mathf.Atan2(headToTarget.y, headToTarget.x) * Mathf.Rad2Deg;
    }

    private void Fire()
    {
        bullet.GetComponent<Enemy_FireMode_AimToSnipeBulletSet>().angle = transform.eulerAngles;
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
}