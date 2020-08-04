using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_SP_TurretFireDirection : MonoBehaviour
// Script for Stardust Turret Bullet to setup the rotation for the children object
// PS. This script should assign to the StardustTurretWeapon objects
{
    public Vector3 angle;
    
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            Common_Bullet bulletData = transform.GetChild(i).GetComponent<Common_Bullet>();
            bulletData.shootDegree = angle.z + bulletData.shootDegree + 90;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
