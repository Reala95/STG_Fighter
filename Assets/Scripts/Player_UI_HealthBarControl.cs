using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_UI_HealthBarControl : MonoBehaviour
{
    GameObject healthBar;
    GameObject player;
    Common_HP playerHP;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GameObject.Find("BarAnchor");
        player = GameObject.FindGameObjectWithTag("Player");
        playerHP = GameObject.FindGameObjectWithTag("Player").GetComponent<Common_HP>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        healthBar.transform.localScale = new Vector3((float) playerHP.getCurrentHP() / playerHP.getMaxHP(), 1, 1);
    }
}
