﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_SP_TurretWeaponControl : MonoBehaviour
// Script for Stardust Turret to setup the basic weapon data
// PS. This script should assign to the StardustTurret object
{
    public GameObject[] turretBullets = new GameObject[3];
    public int turretBulletLevel = 0;
    public float weaponCD;
    float curWeaponCD = 0;
    public float overloadCD;
    float curOverloadCD = 0;
    public bool isFireAllowed;
    Player_BaseWeaponControl stardustFighterWeapon;
    Player_SpecialAbilityActivation spData;
    Player_SP_TurretTargetSearch radar;

    AudioSource fireSound;

    // Start is called before the first frame update
    void Start()
    {
        stardustFighterWeapon = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_BaseWeaponControl>();
        spData = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_SpecialAbilityActivation>();
        radar = GetComponent<Player_SP_TurretTargetSearch>();

        fireSound = GameObject.Find("StardustTurretWeapon").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (turretBulletLevel != stardustFighterWeapon.baseBulletLevel)
        {
            turretBulletLevel = stardustFighterWeapon.baseBulletLevel;
        }
        if (isFireAllowed != stardustFighterWeapon.isFireAllowed)
        {
            isFireAllowed = stardustFighterWeapon.isFireAllowed;
        }
    }

    private void FixedUpdate()
    {
        if (isFireAllowed)
        {
            if (!spData.getIsActivated())
            {
                curWeaponCD -= Time.fixedDeltaTime;
                if (curWeaponCD <= 0)
                {
                    Fire();
                    radar.setNewTarget();
                    curWeaponCD = weaponCD;
                }
            }
            else
            {
                curOverloadCD -= Time.fixedDeltaTime;
                if (curOverloadCD < 0)
                {
                    Fire();
                    radar.setNewTarget();
                    curOverloadCD = overloadCD;
                }
            }
        }

    }

    private void Fire()
    {
        turretBullets[turretBulletLevel].GetComponent<Player_SP_TurretFireDirection>().angle = transform.eulerAngles;
        fireSound.Play();
        Instantiate(turretBullets[turretBulletLevel], transform.position, Quaternion.identity);
    }
}
