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
        if (Input.GetKeyDown(KeyCode.Space) && !isSnipeActived)
        {
            isSnipeActived = true;
            currentSnipeDuration = snipeDuration;
        }
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
    }

    public void WeaponLevelUp()
    {
        baseBulletLevel += Math.Min(2, baseBulletLevel + 1);
    }
}

