using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_VortexWeaponControl : MonoBehaviour
{
    public GameObject[] baseBullets = new GameObject[3];
    public GameObject vortexSpecialAbility;
    public bool isBlastActived = false;
    public int baseBulletLevel = 0;
    public float weaponCD;
    float currentWeaponCD = 0;
    public float blastCD;
    float currentBlastCD = 0;
    public float blastDuration;
    float currentBlastDuration = 0;

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
        if (Input.GetKeyDown(KeyCode.Space) && !isBlastActived)
        {
            isBlastActived = true;
            currentBlastDuration = blastDuration;
        }
        if (!isBlastActived)
        {
            currentWeaponCD -= Time.fixedDeltaTime;
            if (currentWeaponCD <= 0)
            {
                Fire();
                currentWeaponCD = weaponCD;
            }
        }
        else
        {
            currentBlastCD -= Time.fixedDeltaTime;
            if (currentBlastCD <= 0)
            {
                Blast();
                currentBlastCD = blastCD;
            }
            currentBlastDuration -= Time.fixedDeltaTime;
            if (currentBlastDuration <= 0)
            {
                isBlastActived = false;
            }
        }
    }

    private void Fire()
    {
        baseBullets[baseBulletLevel].transform.position = transform.position;
        Instantiate(baseBullets[baseBulletLevel]);
    }

    private void Blast()
    {
        vortexSpecialAbility.transform.position = transform.position;
        Instantiate(vortexSpecialAbility);
    }

    public void WeaponLevelUp()
    {
        baseBulletLevel += Math.Min(2, baseBulletLevel + 1);
    }
}
