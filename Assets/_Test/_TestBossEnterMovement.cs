using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _TestBossEnterMovement : MonoBehaviour
{
    Vector3 init = new Vector3(0, 14, 0);
    Vector3 pos = new Vector3(0, 4, 0);
    float timepass = 0;
    float speed = 1;
    bool entering = true;
    bool setAll = false;

    Enemy_FIreMode_AimToSnipe boss, snp1, snp2;
    _TestEnemyWeapon bossW;

    // Start is called before the first frame update
    void Start()
    {
        bossW = GetComponent<_TestEnemyWeapon>();
        boss = GetComponent<Enemy_FIreMode_AimToSnipe>();
        snp1 = GameObject.Find("Sniper1").GetComponent<Enemy_FIreMode_AimToSnipe>();
        snp2 = GameObject.Find("Sniper2").GetComponent<Enemy_FIreMode_AimToSnipe>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (entering)
        {
            timepass += Time.fixedDeltaTime;
            transform.position = Vector3.MoveTowards(init, pos, speed * timepass);
            if(transform.position == pos)
            {
                entering = false;
                setAll = true;
            }
        }
        else if (setAll)
        {
            boss.isFireAllowed = true;
            bossW.isFireAllowed = true;
            snp1.isFireAllowed = true;
            snp2.isFireAllowed = true;
            setAll = false;
        }
    }
}
