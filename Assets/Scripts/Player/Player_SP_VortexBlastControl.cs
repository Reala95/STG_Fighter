using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_SP_VortexBlastControl : MonoBehaviour
// Script for Vortex Figter to setup the basic weapon data of its Vortex Blast skill
// PS. This script should assign to the VortexFighter object
{
    public GameObject vortexBlastBullet;
    public float blastCD;
    float curBlastCD = 0;
    Player_BaseWeaponControl weaponData;
    Player_SpecialAbilityActivation spData;
    bool isBlastAllowed;

    AudioSource fireSound;

    // Start is called before the first frame update
    void Start()
    {
        weaponData = GetComponent<Player_BaseWeaponControl>();
        spData = GetComponent<Player_SpecialAbilityActivation>();
        fireSound = GameObject.Find("VortexFighterWeapon").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spData.isSPAllowed)
        {
            if (spData.getIsActivated())
            {
                weaponData.isFireAllowed = false;
                isBlastAllowed = true;
            }
            else
            {
                weaponData.isFireAllowed = true;
                isBlastAllowed = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isBlastAllowed)
        {
            curBlastCD -= Time.fixedDeltaTime;
            if(curBlastCD <= 0)
            {
                Blast();
                curBlastCD = blastCD;
            }
        }
    }

    private void Blast()
    {
        fireSound.Play();
        Instantiate(vortexBlastBullet, transform.position, Quaternion.identity);
    }
}
