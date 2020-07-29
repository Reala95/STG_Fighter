using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_SP_SolarShieldControl : MonoBehaviour
{
    public GameObject solarShieldPrefab;
    GameObject solarShieldClone;
    Player_BaseWeaponControl weaponData;
    Player_SpecialAbilityActivation spData;
    bool shieldActivated = false;

    // Start is called before the first frame update
    void Start()
    {
        weaponData = GetComponent<Player_BaseWeaponControl>();
        spData = GetComponent<Player_SpecialAbilityActivation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spData.isActivated && !shieldActivated)
        {
            Instantiate(solarShieldPrefab, transform.position, Quaternion.identity);
            solarShieldClone = GameObject.FindGameObjectWithTag("Shield");
            shieldActivated = true;
            weaponData.isFireAllowed = false;
        }
        else if (!spData.isActivated)
        {
            Destroy(solarShieldClone);
            weaponData.isFireAllowed = true;
            shieldActivated = false;
        }
    }
}
