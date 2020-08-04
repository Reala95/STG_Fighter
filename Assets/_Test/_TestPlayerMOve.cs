using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _TestPlayerMOve : MonoBehaviour
{
    Rigidbody2D player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 mouse = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        player.velocity = 18 * (mouse - (Vector2)transform.position);
    }
}
