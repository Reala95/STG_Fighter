using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_MovemovementControl : MonoBehaviour
{
    public float sensitivity;
    public bool isAllowMoving;

    Rigidbody2D player;
    Player_BaseWeaponControl playerWeapon;
    Player_SpecialAbilityActivation playerSP;
    Common_HP playerHP;

    // Variable for entering animation
    Vector3 initPos;
    Vector3 readyPos = new Vector3(0, 0, 0);
    float readyMoveVelocity = 2;
    float moveTime = 0;
    bool isOnReady = true;
    float barLoadTime = 4.5f;
    float curBarLoadTime = 0;

    Player_UI_HealthBarControl healthBar;
    Player_UI_SkillBarControl skillBar;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        isAllowMoving = false;
        playerWeapon = GetComponent<Player_BaseWeaponControl>();
        playerWeapon.isFireAllowed = false;
        playerSP = GetComponent<Player_SpecialAbilityActivation>();
        playerSP.isSPAllowed = false;
        playerHP = GetComponent<Common_HP>();
        playerHP.isInvicible = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        initPos = transform.position;
        healthBar = GameObject.FindGameObjectWithTag("StatusBar/HP").GetComponent<Player_UI_HealthBarControl>();
        skillBar = GameObject.FindGameObjectWithTag("StatusBar/SP").GetComponent<Player_UI_SkillBarControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if(curBarLoadTime <= barLoadTime)
        {
            skillBar.setBarRatio(0, true);
            healthBar.setBarRatio(Mathf.Min(curBarLoadTime / barLoadTime, 1));
            curBarLoadTime += Time.deltaTime;
        }

    }

    private void FixedUpdate()
    {
        if (isAllowMoving)
        {
            Vector2 mouse = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition);
            player.velocity = sensitivity * (mouse - (Vector2)transform.position);
        }
        else if (isOnReady)
        {
            transform.position = Vector3.MoveTowards(initPos, readyPos, readyMoveVelocity * moveTime);
            moveTime += Time.fixedDeltaTime;
            if(transform.position == readyPos)
            {
                isOnReady = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.lockState = CursorLockMode.Confined;
                isAllowMoving = true;
                playerWeapon.isFireAllowed = true;
                playerSP.isSPAllowed = true;
                playerHP.isInvicible = false;
                healthBar.setInOpt(true);
                skillBar.setInOpt(true);
            }
        } 
    }
}
