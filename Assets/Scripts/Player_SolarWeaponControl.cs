using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Player_SolarWeaponControl : MonoBehaviour
{
    public GameObject solarFighter;
    public GameObject baseBullet;
    int baseBulletCD = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        baseBulletCD++;
        if(baseBulletCD == 5)
        {
            Fire();
            baseBulletCD = 0;
        }
    }

    private void Fire()
    {
        for (int i = 0; i < 3; i++)
        {
            baseBullet.transform.position = new Vector3(
                solarFighter.transform.position.x + (i - 1) * (0.05f),
                solarFighter.transform.position.y + 0.4f,
                solarFighter.transform.position.z);
            Instantiate(baseBullet);
        }
    }
}
