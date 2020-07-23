using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_UI_HealthBarControl : MonoBehaviour
{
    GameObject healthBar;
    Common_HP playerHP;

    // Start is called before the first frame update
    void Start()
    {
        playerHP = GameObject.FindGameObjectWithTag("Player").GetComponent<Common_HP>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.localScale = new Vector3((float) playerHP.getCurrentHP() / playerHP.getMaxHP(), 1, 1);
    }
}
