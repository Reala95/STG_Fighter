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
    public Vector2 initialVelocity;
    public bool isPiercing = false;

    // Bool for check if using other script to control this bullet
    public bool isUsingAdditionScripts = false;

    // String array for checking target tag
    string[] targetList = { "Enemy", "Player" };

    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Rigidbody2D>();
        bullet.velocity = initialVelocity;

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
                if (!isPiercing)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
