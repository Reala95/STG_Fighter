using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common_Bullet : MonoBehaviour
// Script for base bullet
{
    Rigidbody2D bullet;
    Common_HP targetHP;
    public int atk;
    public int target; // 0 = Enemy; 1 = Player
    public float linearVelocity;
    public double shootDegree;
    public bool isPiercing = false;
    public bool needToRotate = false;

    // Bool for check if using other script to control this bullet
    //public bool isUsingAdditionScripts = false;

    // String array for checking target tag
    string[] targetList = { "Enemy", "Player" };

    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Rigidbody2D>();
        if (needToRotate)
        {
            bullet.transform.Rotate(new Vector3(0, 0, Convert.ToSingle(shootDegree) - 90.0f));
        }
        bullet.velocity = getVelocity();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x >= 7.6 || transform.position.x <= -7.6 || transform.position.y >=5 || transform.position.y <= -5)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject hitTarget = collision.gameObject;
        if (hitTarget.tag == targetList[target])
        {
            targetHP = hitTarget.GetComponent<Common_HP>();
            if (!targetHP.isInvicible)
            {
                targetHP.damage(atk);
            }
            if (!isPiercing)
            {
                Destroy(gameObject);
            }

        }
    }

    public Vector2 getVelocity()
    {
        return new Vector2(
            linearVelocity * Convert.ToSingle(Math.Cos(Math.PI * shootDegree / 180)),
            linearVelocity * Convert.ToSingle(Math.Sin(Math.PI * shootDegree / 180))
            );
    }
}
