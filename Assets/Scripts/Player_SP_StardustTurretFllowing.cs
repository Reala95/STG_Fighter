using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_SP_StardustTurretFllowing : MonoBehaviour
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
        stardustTurretSet.velocity = sensitivity * (Vector2)(stardustFighter.transform.position - transform.position);
    }
}
