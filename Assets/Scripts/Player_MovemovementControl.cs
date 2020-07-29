using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_MovemovementControl : MonoBehaviour
{
    public float sensitivity = 18.0f;
    Rigidbody2D player;
    bool allowMoving = true;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            allowMoving = !allowMoving;
            player.velocity = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        if (allowMoving)
        {
            Vector2 mouse = new Vector2(
            Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, -7.1f, 7.1f),
            Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).y, -4.1f, 4.1f)
            );
            player.velocity = sensitivity * (mouse - (Vector2)transform.position);
        }
    }
}
