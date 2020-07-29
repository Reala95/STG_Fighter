using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_SP_VortexBlastControl : MonoBehaviour
{
    public GameObject vortexBlastBullet;
    public float blastCD;
    float curBlastCD = 0;
    Player_BaseWeaponControl weaponData;
    Player_SpecialAbilityActivation spData;
    bool isBlastAllowed;

    // Start is called before the first frame update
    void Start()
    {
        weaponData = GetComponent<Player_BaseWeaponControl>();
        spData = GetComponent<Player_SpecialAbilityActivation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spData.isActivated)
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
        Instantiate(vortexBlastBullet, transform.position, Quaternion.identity);
    }
}
