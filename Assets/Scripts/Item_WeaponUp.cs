using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_WeaponUp : MonoBehaviour
{
    public Vector2 velocity;

    Rigidbody2D item;

    // Start is called before the first frame update
    void Start()
    {
        item = GetComponent<Rigidbody2D>();
        item.velocity = velocity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPos.x < -10 || screenPos.y < -10 || screenPos.x > Screen.width + 20 || screenPos.y > Screen.height + 20)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Touched!");
        if (collision.gameObject.tag == "Player")
        {
            Player_BaseWeaponControl playerWeapon = collision.gameObject.GetComponent<Player_BaseWeaponControl>();
            playerWeapon.WeaponLevelUp();
            Debug.Log("LevelUp!");
            Destroy(gameObject);
        }
    }
}
