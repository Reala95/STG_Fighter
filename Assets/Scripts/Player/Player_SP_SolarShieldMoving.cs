using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_SP_SolarShieldMoving : MonoBehaviour
// Script for Solar Shield skill to let the shield move and making the shield activating animation
// PS. This script should assign to the SolarSpecialAbility object
{
    // Shield move related
    public float sensitivity;
    Rigidbody2D solarShield;

    // Shield animation related
    float size = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        solarShield = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate() 
    {
        Vector2 mouse = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        solarShield.velocity = sensitivity * (mouse - (Vector2)transform.position);
        if (size < 4)
        {
            size += 4 * Time.fixedDeltaTime;
            transform.localScale = new Vector3(size, size, 1);
        }
    }
}
