using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_SP_StardustTurretFllowing : MonoBehaviour
// Script for Stardust Turret to let following the player object
// PS. This script should assign to the StardustTurretSet object
{
    public float sensitivity;
    GameObject stardustFighter;
    Rigidbody2D stardustTurretSet;

    // Start is called before the first frame update
    void Start()
    {
        stardustFighter = GameObject.FindGameObjectWithTag("Player");
        stardustTurretSet = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(stardustFighter == null)
        {
            Destroy(gameObject);
        }
        else
        {
            stardustTurretSet.velocity = sensitivity * (Vector2)(stardustFighter.transform.position - transform.position);
        }
        
    }
}
