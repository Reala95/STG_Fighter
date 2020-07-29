using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_SP_TurretFireDirection : MonoBehaviour
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
