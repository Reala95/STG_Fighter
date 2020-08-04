using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_SP_NebulaSnipeGenerator : MonoBehaviour
// Script for Nebula Snipe skill to gnerate skill bullet when bullet hit the targets 
// PS. This script should assign to the NebulaBaseBullet object
{
    public GameObject nebulaSnipeBullet;
    public int nebulaHealAmount;
    Common_HP nebulaFighterHP;
    Player_BaseWeaponControl weaponData;
    Player_SpecialAbilityActivation spData;
    int curLevel;
    bool isSPActived;

    AudioSource fireSound;

    // Start is called before the first frame update
    void Start()
    {
        nebulaFighterHP = GameObject.FindGameObjectWithTag("Player").GetComponent<Common_HP>();
        weaponData = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_BaseWeaponControl>();
        curLevel = weaponData.baseBulletLevel;
        spData = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_SpecialAbilityActivation>();
        isSPActived = spData.getIsActivated();

        // Load fire sound
        fireSound = GameObject.Find("NebulaSnipe").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (curLevel == 2 || isSPActived)
            {
                nebulaFighterHP.heal(nebulaHealAmount);
            }
            if (isSPActived)
            {
                Vector3 snipePos = new Vector3(Random.Range(-7.6f, 7.6f), -5, 0);
                nebulaSnipeBullet.GetComponent<Common_Bullet>().shootDegree = getTargetAngle(transform.position, snipePos);
                fireSound.Play();
                Instantiate(nebulaSnipeBullet, snipePos, Quaternion.identity);
            }
            
        }
    }

    private float getTargetAngle(Vector3 targetPos, Vector3 initPos)
    {
        float x = targetPos.x - initPos.x;
        float y = targetPos.y - initPos.y;
        return Mathf.Atan2(y, x) * Mathf.Rad2Deg;
    }
}
