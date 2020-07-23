using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Player_SolarWeaponControl : MonoBehaviour
{
    public GameObject[] baseBullets = new GameObject[3];
    public GameObject solarSpecialAbility;
    public bool isShieldActived = false;
    int baseBulletLevel = 0;
    int baseBulletCD = 0;


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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            solarSpecialAbility.transform.position = transform.position;
            Instantiate(solarSpecialAbility);
        }
        if (!isShieldActived)
        {
            baseBulletCD++;
            if (baseBulletCD == 5)
            {
                Fire();
                baseBulletCD = 0;
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
        baseBulletLevel += 1;
        if(baseBulletLevel > 2)
        {
            baseBulletLevel = 2;
        }
    }
}
