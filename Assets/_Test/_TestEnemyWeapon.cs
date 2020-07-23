using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _TestEnemyWeapon : MonoBehaviour
{
    public GameObject enemy;
    public GameObject bullet;
    double[] degrees = { 30, 150, 270 };
    Common_Bullet bulletData;
    int count = 0;
    
        // Start is called before the first frame update
    void Start()
    {
        bulletData = bullet.GetComponent<Common_Bullet>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        count++;
        if(count == 6)
        {
            Fire();
            count = 0;
        }

    }

    private void Fire()
    {
        for(int i = 0; i < 3; i++)
        {
            bulletData.shootDegree = degrees[i];
            bullet.transform.position = enemy.transform.position;
            Instantiate(bullet);
            degrees[i] += 5;
        }
    }
}
