using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_SolarSpecialAvility : MonoBehaviour
{
    public int shieldDamage;
    public float shieldDuration;
    public float healCount;
    public int healAmount;
    GameObject solarFighter;
    Common_HP solarFighterHP;
    Player_SolarWeaponControl solarFighterWeapon;
    float currentHealCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        solarFighter = GameObject.FindGameObjectWithTag("Player");
        solarFighterHP = solarFighter.GetComponent<Common_HP>();
        solarFighterWeapon = solarFighter.GetComponent<Player_SolarWeaponControl>();
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), solarFighter.GetComponent<Collider2D>());
        solarFighterHP.isInvicible = true;
        solarFighterWeapon.isShieldActived = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        currentHealCount -= Time.fixedDeltaTime;
        if(currentHealCount <= 0) 
        {
            solarFighterHP.heal(healAmount);
            currentHealCount = healCount;
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
