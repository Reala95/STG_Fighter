using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_SolarSpecialAvility : MonoBehaviour
{
    public int shieldDamage;
    public float shieldDuration;
    GameObject solarFighter;
    Common_HP solarFighterHP;
    Player_SolarWeaponControl solarFighterWeapon;
    int healCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        solarFighter = GameObject.FindGameObjectWithTag("Player");
        solarFighterHP = solarFighter.GetComponent<Common_HP>();
        solarFighterWeapon = solarFighter.GetComponent<Player_SolarWeaponControl>();
        solarFighterHP.isInvicible = true;
        solarFighterWeapon.isShieldActived = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        healCount++;
        if(healCount == 20) 
        {
            solarFighterHP.heal(1);
            healCount = 0;
        }
        shieldDuration-= Time.fixedDeltaTime;
        if(shieldDuration <= 0)
        {
            Destroy(gameObject);
            solarFighterHP.isInvicible = false;
            solarFighterWeapon.isShieldActived = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Common_HP>().damage(shieldDamage);
        } 
        else if (collision.gameObject.tag == "Bullet/Enemy")
        {
            Destroy(collision.gameObject);
        }
    }
}
