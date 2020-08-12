using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_MovemovementControl : MonoBehaviour
// Script of player's movement control and entering animation 
{
    // Basic movement related
    public float sensitivity;
    public bool isAllowMoving;
    Rigidbody2D player;

    // Entering animation realted
    GameObject shield;
    Player_BaseWeaponControl playerWeapon;
    Player_SpecialAbilityActivation playerSP;
    Common_HP playerHP;
    Vector3 initPos;
    Vector3 readyPos = new Vector3(0, 0, 0);
    const float moveTime = 0.25f;
    float curMoveTime = 0;
    const float barLoadTime = 2.75f;
    float curBarLoadTime = 0;
    const float invincibleRemainTime = 2.0f;
    float curInvincibleRemainTime = 0;
    bool isStillInvincible = true;

    // UI Related
    Player_UI_HealthBarControl healthBar;
    Player_UI_SkillBarControl skillBar;
    UI_GamePasue pasueMenu;

    // Boss Fighter Related
    GameObject winMenu = StaticGameData.winMenu;
    float endingVelocity = 1.0f;
    bool isBossDead = false;
    bool endAnimation = false;
    bool win = false;

    // Start is called before the first frame update
    void Start()
    {
        // Preparing for entering animation
        player = GetComponent<Rigidbody2D>();
        isAllowMoving = false;
        shield = GameObject.Find("Player_InvincibleShield");
        playerWeapon = GetComponent<Player_BaseWeaponControl>();
        playerWeapon.isFireAllowed = false;
        playerSP = GetComponent<Player_SpecialAbilityActivation>();
        playerSP.isSPAllowed = false;
        playerHP = GetComponent<Common_HP>();
        playerHP.isInvicible = true;
        initPos = transform.position;
        healthBar = GameObject.FindGameObjectWithTag("StatusBar/HP").GetComponent<Player_UI_HealthBarControl>();
        healthBar.setInOpt(false);
        skillBar = GameObject.FindGameObjectWithTag("StatusBar/SP").GetComponent<Player_UI_SkillBarControl>();
        skillBar.setInOpt(false);
        pasueMenu = GameObject.FindGameObjectWithTag("GameManager").GetComponent<UI_GamePasue>();
        pasueMenu.isAvaliable = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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
            if (isStillInvincible)
            {
                curInvincibleRemainTime += Time.fixedDeltaTime;
                if(curInvincibleRemainTime > invincibleRemainTime)
                {
                    playerHP.isInvicible = false;
                    isStillInvincible = false;
                    shield.SetActive(false);
                }
            }
            Vector2 mouse = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition);
            player.velocity = sensitivity * (mouse - (Vector2)transform.position);
        }
        else if (isBossDead)
        {
            Debug.Log(isBossDead);
            player.velocity = new Vector2(0, endingVelocity);
            playerWeapon.isFireAllowed = false;
            playerSP.isSPAllowed = false;
            isBossDead = false;
            endAnimation = true;
            
        }
        else if (endAnimation)
        {
            endingVelocity += Time.fixedDeltaTime;
            player.velocity = new Vector2(0, endingVelocity);
            if (transform.position.y >= 6)
            {
                pasueMenu.isAvaliable = false;
                winMenu.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                player.velocity = Vector2.zero;
                endAnimation = false;
                win = true;
            }
        }
        else if (win)
        {

        }
        else
        {
            curMoveTime += Time.fixedDeltaTime;
            transform.position = Vector3.MoveTowards(initPos, readyPos, curMoveTime / moveTime);
            if(transform.position == readyPos)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.lockState = CursorLockMode.Confined;
                isAllowMoving = true;
                playerWeapon.isFireAllowed = true;
                playerSP.isSPAllowed = true;
                healthBar.setInOpt(true);
                skillBar.setInOpt(true);
                pasueMenu.isAvaliable = true;
            }
        } 
    }

    private void OnDestroy()
    {
        healthBar.setInOpt(false);
        skillBar.setInOpt(false);
    }

    public void setBossDead(bool isBossDead)
    {
        this.isBossDead = isBossDead;
    }

    public void Stop()
    {
        player.velocity = Vector2.zero;
    }
}
