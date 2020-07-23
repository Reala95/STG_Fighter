using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Test_EnemyWeaponControl : MonoBehaviour
{
    public GameObject bullet;
    Rigidbody2D enemy;
    Common_Bullet bulletData;
    int count = 0;
    int[] fireDegrees = {30, 150, 270};
    float linearVelocity = 4;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
        bulletData = bullet.GetComponent<Common_Bullet>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        count++;
        if(count == 10)
        {
            Fire();
            count = 0;
        }
    }

    private void Fire()
    {
        for (int i = 0; i < 3; i++)
        {
            double angle = Math.PI * fireDegrees[i] / 180;
            bullet.transform.position = new Vector3(
                enemy.transform.position.x + (Convert.ToSingle(Math.Cos(angle) * 0.4)),
                enemy.transform.position.y + (Convert.ToSingle(Math.Sin(angle) * 0.4)),
                enemy.transform.position.z
                );
            bulletData.initialVelocity = new Vector2(
                enemy.transform.position.x + (Convert.ToSingle(Math.Cos(angle) * linearVelocity)),
                enemy.transform.position.y + (Convert.ToSingle(Math.Sin(angle) * linearVelocity))
                );
            Instantiate(bullet);
            fireDegrees[i] += 5;
        }
    }
}
