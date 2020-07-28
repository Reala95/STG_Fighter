using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_NebulaWeaponControl : MonoBehaviour
{
    public GameObject[] baseBullets = new GameObject[3];
    public bool isSnipeActived = false;
    public int baseBulletLevel = 0;
    public float weaponCD;
    float currentWeaponCD = 0;
    public float snipeDuration;
    float currentSnipeDuration;

    SE_PlayerSoundManager playerSoundManager;

    // Start is called before the first frame update
    void Start()
    {
        playerSoundManager = GameObject.FindGameObjectWithTag("PlayerSound").GetComponent<SE_PlayerSoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isSnipeActived)
        {
            isSnipeActived = true;
            currentSnipeDuration = snipeDuration;
        }
    }

    private void FixedUpdate()
    {
        currentWeaponCD -= Time.fixedDeltaTime;
        if (currentWeaponCD <= 0)
        {
            Fire();
            currentWeaponCD = weaponCD;
        }
        if (isSnipeActived)
        {
            currentSnipeDuration -= Time.fixedDeltaTime;
            if(currentSnipeDuration <= 0)
            {
                isSnipeActived = false;
            }
        }

    }

    private void Fire()
    {
        baseBullets[baseBulletLevel].transform.position = transform.position;
        Instantiate(baseBullets[baseBulletLevel]);
        playerSoundManager.playerSound(playerSoundManager.nebulaFire);
    }

    public void WeaponLevelUp()
    {
        baseBulletLevel += Math.Min(2, baseBulletLevel + 1);
    }
}

