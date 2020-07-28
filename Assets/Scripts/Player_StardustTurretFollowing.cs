using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_StardustTurretFollowing : MonoBehaviour
{
    GameObject player;
    Rigidbody2D turretSet;
    Common_HP playerHP;
    float sensitivity = 15.0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHP = player.GetComponent<Common_HP>();
        turretSet = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (player == null)
        {
            Destroy(gameObject);
        }
        turretSet.velocity = sensitivity * (Vector2)(player.transform.position - transform.position);
    }
}
