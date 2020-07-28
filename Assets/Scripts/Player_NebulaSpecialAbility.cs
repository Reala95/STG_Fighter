using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_NebulaSpecialAbility : MonoBehaviour
{
    public int healAmount;
    public GameObject snipeBullet;
    Common_HP nebulaFighterHP;
    Common_Bullet snipeBulletData;
    int weaponLevel;
    bool isSnipeActived;

    // Start is called before the first frame update
    void Start()
    {
        nebulaFighterHP = GameObject.FindGameObjectWithTag("Player").GetComponent<Common_HP>();
        snipeBulletData = snipeBullet.GetComponent<Common_Bullet>();
        weaponLevel = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_NebulaWeaponControl>().baseBulletLevel;
        isSnipeActived = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_NebulaWeaponControl>().isSnipeActived;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        if (transform.position.y < 5 && transform.position.y > -5 && transform.position.x < 7.6 && transform.position.x > -7.6 )
        {
            if(weaponLevel == 2)
            {
                nebulaFighterHP.heal(healAmount);
            }
            if (isSnipeActived)
            {
                snipeBullet.transform.position = new Vector3(UnityEngine.Random.Range(-7.5f, 7.5f), -4.5f, 0);
                snipeBulletData.shootDegree = getSnipeAngle();
                Instantiate(snipeBullet);
            }
            
        }
    }

    private float getSnipeAngle()
    {
        Vector3 headToTarget = transform.position - snipeBullet.transform.position;
        return Mathf.Atan2(headToTarget.y, headToTarget.x) * Mathf.Rad2Deg;
    }
}
