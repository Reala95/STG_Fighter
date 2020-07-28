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

    SE_PlayerSoundManager playerSoundManager;

    // Start is called before the first frame update
    void Start()
    {
        playerSoundManager = GameObject.FindGameObjectWithTag("PlayerSound").GetComponent<SE_PlayerSoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isBlastActived)
        {
            isBlastActived = true;
            currentBlastDuration = blastDuration;
        }
    }

    private void FixedUpdate()
    {
        
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
        playerSoundManager.playerSound(playerSoundManager.vortexFire);
    }

    private void Blast()
    {
        vortexSpecialAbility.transform.position = transform.position;
        Instantiate(vortexSpecialAbility);
        playerSoundManager.playerSound(playerSoundManager.vortexBlast);
    }

    public void WeaponLevelUp()
    {
        baseBulletLevel += Math.Min(2, baseBulletLevel + 1);
    }
}
