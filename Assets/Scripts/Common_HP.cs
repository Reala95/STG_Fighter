using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common_HP : MonoBehaviour
{
    public int HP;
    public int crashDamage;
    public int crashalbeTarget; // 0 = Enemy; 1 = Player
    public bool isInvicible = false;
    int maxHP;
    int currentHP;
    Common_HP crashTargetHP;

    // String array for checking target tag
    string[] targetList = { "Enemy", "Player" };

    // Start is called before the first frame update
    void Start()
    {
        maxHP = HP;
        currentHP = HP;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHP == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "Bullet" && collision.gameObject.tag == targetList[crashalbeTarget])
        {
            crashTargetHP = collision.gameObject.GetComponent<Common_HP>();
            if (!crashTargetHP.isInvicible)
            {
                crashTargetHP.damage(crashDamage);
            }
        }
        else
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }

    public void damage(int hit)
    {
        currentHP = Math.Max(0, currentHP - hit);
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
