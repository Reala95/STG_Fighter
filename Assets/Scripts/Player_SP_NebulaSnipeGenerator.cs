using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_SP_NebulaSnipeGenerator : MonoBehaviour
{
    public GameObject nebulaSnipeBullet;
    public int nebulaHealAmount;
    Common_HP nebulaFighterHP;
    Player_BaseWeaponControl weaponData;
    Player_SpecialAbilityActivation spData;

    // Start is called before the first frame update
    void Start()
    {
        nebulaFighterHP = GameObject.FindGameObjectWithTag("Player").GetComponent<Common_HP>();
        weaponData = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_BaseWeaponControl>();
        spData = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_SpecialAbilityActivation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        if (!GetComponent<Common_Bullet>().isOutOfScreen())
        {
            if (weaponData.baseBulletLevel == 2)
            {
                nebulaFighterHP.heal(nebulaHealAmount);
            }
            if (spData.isActivated)
            {
                Vector3 snipePos = new Vector3(Random.Range(-7.6f, 7.6f), -5, 0);
                nebulaSnipeBullet.GetComponent<Common_Bullet>().shootDegree = getTargetAngle(transform.position, snipePos);
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
