using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common_HP : MonoBehaviour
// Script for all object with HP
{
    // Basic HP related data setting
    public int HP;
    int maxHP;
    int currentHP;
    public bool isInvicible;

    // Crash attack realated 
    public int crashDamage;
    public int crashDefence;
    public int crashalbeTarget; // 0 = Enemy; 1 = Player
    
    // Item drop related for enemy object
    Enemy_DropItemWhenDie itemDrop;

    // String array for checking target tag
    string[] targetList = { "Enemy", "Player" };

    // SE related
    public string hitSoundName;
    AudioSource hitSound;
    public string killedSoundName;
    AudioSource killedSound;

    // Start is called before the first frame update
    void Start()
    {
        maxHP = HP;
        currentHP = HP;
        if(transform.tag == "Enemy")
        {
            itemDrop = GetComponent<Enemy_DropItemWhenDie>();
        }

        hitSound = GameObject.Find(hitSoundName).GetComponent<AudioSource>();
        killedSound = GameObject.Find(killedSoundName).GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHP == 0)
        {
            if (itemDrop != null)
            {
                itemDrop.Drop();
            }
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "Bullet" && collision.gameObject.tag == targetList[crashalbeTarget])
        {
            Common_HP crashTargetHP = collision.gameObject.GetComponent<Common_HP>();
            if (!crashTargetHP.isInvicible)
            {
                crashTargetHP.crash(crashDamage);
            }
        }
        else
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }

    private void OnDestroy()
    {
        if (killedSound != null && currentHP == 0)
        {
            killedSound.Play();
        }
    }

    public void damage(int hit)
    {
        currentHP = Math.Max(0, currentHP - hit);
        if(hitSound != null)
        {
            hitSound.Play();
        }
    }

    public void crash(int hit)
    {
        currentHP = Math.Max(0, currentHP - Mathf.Max(hit - crashDefence, 0));
    }

    public void heal(int hit)
    {
        currentHP = Math.Min(maxHP, currentHP + hit);
    }

    public int getMaxHP()
    {
        return maxHP;
    }

    public int getCurrentHP()
    {
        return currentHP;
    }
}
