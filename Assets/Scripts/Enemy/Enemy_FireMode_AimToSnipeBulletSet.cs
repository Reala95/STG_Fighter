using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_FireMode_AimToSnipeBulletSet : MonoBehaviour
/* 
 * This script is use for the bullet prefab that fired by the enemy object with the  "Enemy_FIreMode_AimToSnipe" firemode script.
 */
{
    public Vector3 angle;

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(angle);
        for (int i = 0; i < transform.childCount; i++)
        {
            Common_Bullet bulletData = transform.GetChild(i).GetComponent<Common_Bullet>();
            bulletData.shootDegree = angle.z + bulletData.shootDegree - 90;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
