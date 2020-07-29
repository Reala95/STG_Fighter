using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_BaseWeaponControl : MonoBehaviour
{
    public GameObject[] baseBullets = new GameObject[3];
    public int baseBulletLevel = 0;
    public float weaponCD;
    float curWeaponCD = 0;
    public bool isFireAllowed = true;

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
        if (isFireAllowed)
        {
            curWeaponCD -= Time.fixedDeltaTime;
            if (curWeaponCD <= 0)
            {
                Fire();
                curWeaponCD = weaponCD;
            }
        }
        
    }

    private void Fire()
    {
        Instantiate(baseBullets[baseBulletLevel], transform.position, Quaternion.identity);
    }

    public void WeaponLevelUp()
    {
        baseBulletLevel += Mathf.Min(2, baseBulletLevel + 1);
    }
}
