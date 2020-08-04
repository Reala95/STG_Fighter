using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_SP_SolarShieldControl : MonoBehaviour
// Script for Solar Shield skill to generate or destroy shield object
// PS. This script should assign to the SolarFighter object
{
    public GameObject solarShieldPrefab;
    GameObject solarShieldClone;
    Player_BaseWeaponControl weaponData;
    Player_SpecialAbilityActivation spData;
    Common_HP hpData;
    bool shieldActivated = false;

    // Start is called before the first frame update
    void Start()
    {
        weaponData = GetComponent<Player_BaseWeaponControl>();
        spData = GetComponent<Player_SpecialAbilityActivation>();
        hpData = GetComponent<Common_HP>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spData.getIsActivated() && !shieldActivated)
        {
            Instantiate(solarShieldPrefab, transform.position, Quaternion.identity);
            solarShieldClone = GameObject.FindGameObjectWithTag("Shield");
            shieldActivated = true;
            weaponData.isFireAllowed = false;
            hpData.isInvicible = true;
        }
        else if (!spData.getIsActivated() && solarShieldClone != null)
        {
            Destroy(solarShieldClone);
            shieldActivated = false;
            weaponData.isFireAllowed = true;
            hpData.isInvicible = false;
        }
    }
}
