using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_SP_SolarShieldBody : MonoBehaviour
// Script for Solar Shield skill for reflect bullet and making damage or healing player
// PS. This script should assign to the SolarSpecialAbility object
{
    public GameObject returnBullet;
    public int shieldDamage;
    public int shieldHealAmount;
    public float shieldHealCD;
    GameObject solarFighter;
    Common_HP solarFighterHP;
    float curShieldHealCD;

    public string audioSourceName;
    AudioSource reflectionSound;
    

    // Start is called before the first frame update
    void Start()
    {
        solarFighter = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreCollision(solarFighter.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        solarFighterHP = solarFighter.GetComponent<Common_HP>();
        curShieldHealCD = shieldHealCD;

        reflectionSound = GameObject.Find(audioSourceName).GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        curShieldHealCD -= Time.fixedDeltaTime;
        if(curShieldHealCD <= 0)
        {
            solarFighterHP.heal(shieldHealAmount);
            curShieldHealCD = shieldHealCD;
        }
        else if(GameObject.FindGameObjectsWithTag("Player").Length == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        GameObject hitTarget = collision.gameObject;
        if(hitTarget.tag == "Enemy")
        {
            hitTarget.GetComponent<Common_HP>().crash(shieldDamage);
        }
        else if(hitTarget.tag == "Bullet/Enemy")
        {
            returnBullet.GetComponent<SpriteRenderer>().sprite = hitTarget.GetComponent<SpriteRenderer>().sprite;
            returnBullet.GetComponent<Common_Bullet>().presetVelocity = hitTarget.GetComponent<Rigidbody2D>().velocity * -2;
            returnBullet.GetComponent<Common_Bullet>().atk = hitTarget.GetComponent<Common_Bullet>().atk * 3;
            returnBullet.GetComponent<BoxCollider2D>().size = hitTarget.GetComponent<BoxCollider2D>().size;
            Instantiate(returnBullet, hitTarget.transform.position, Quaternion.Inverse(hitTarget.transform.rotation));
            Destroy(hitTarget);
            reflectionSound.Play();
        }
    }
}
