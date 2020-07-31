using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_WeaponUp : MonoBehaviour
{
    public Vector2 velocity;

    Rigidbody2D item;
    bool outOfScreen = false;

    // Start is called before the first frame update
    void Start()
    {
        item = GetComponent<Rigidbody2D>();
        item.velocity = this.velocity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (transform.position.x > 7.6 || transform.position.x < -7.6 || transform.position.y > 5 || transform.position.y < -5)
        {
            outOfScreen = true;
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
    public bool isOutOfScreen()
    {
        return outOfScreen;
    }
}
