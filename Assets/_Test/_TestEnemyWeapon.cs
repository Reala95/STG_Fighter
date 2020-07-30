using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _TestEnemyWeapon : MonoBehaviour
{
    public GameObject enemy;
    public GameObject bullet;
    double[] degrees = { 30, 150, 270 };
    public bool isFireAllowed;
    Common_Bullet bulletData;
    public float count;
    float curCount = 0;
    
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
        curCount -= Time.fixedDeltaTime;
        if(curCount <= 0 && isFireAllowed)
        {
            Fire();
            curCount = count;
        }

    }

    private void Fire()
    {
        for(int i = 0; i < 3; i++)
        {
            bulletData.shootDegree = degrees[i];
            bullet.transform.position = enemy.transform.position;
            Instantiate(bullet);
            degrees[i] = (degrees[i] + 5) % 360;
        }
    }
}
