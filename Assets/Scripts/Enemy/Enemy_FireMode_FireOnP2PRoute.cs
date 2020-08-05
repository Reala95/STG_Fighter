using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy_FireMode_FireOnP2PRoute : MonoBehaviour
{
    public GameObject bullet;
    public float firstShotWaitTime; // Wait time before the fire shot
    public float reloadTime; // Interval between fire phase
    float curReloadTime = 0;
    public int bulletClip; // The number of firing whitin a fire phase
    int curBulletClip = 0;
    public int clipAmount; // The number of fire phase (inifinite clip when set to -1)
    public float fireInterval; // Fire interval within a fire phase (If clip is 0, then set this to 0)
    float curFireInterval = 0;
    public bool isFollowingParentsRotation;
    public bool isFireAllowed = true;

    bool isReloading = false;
    bool isFiring = false;

    // Start is called before the first frame update
    void Start()
    {
        isReloading = true;
        curReloadTime = firstShotWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (isFireAllowed && (clipAmount > 0 || clipAmount == -1))
        {
            if (isReloading)
            {
                curReloadTime -= Time.fixedDeltaTime;
                if (curReloadTime <= 0)
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
                if (curFireInterval <= 0)
                {
                    Fire();
                    curFireInterval = fireInterval;
                    curBulletClip--;
                }
                if (curBulletClip == 0)
                {
                    curReloadTime = reloadTime;
                    if (clipAmount > 0)
                    {
                        clipAmount--;
                    }
                    isReloading = true;
                    isFiring = false;
                }
            }
        }
    }

    private void Fire()
    {
        if (isFollowingParentsRotation)
        {
            bullet.GetComponent<Enemy_FireMode_AimToSnipeBulletSet>().angle = transform.eulerAngles;
        }
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
}
