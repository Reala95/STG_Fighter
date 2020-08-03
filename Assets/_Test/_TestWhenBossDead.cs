using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _TestWhenBossDead : MonoBehaviour
{
    public GameObject winMenu;

    GameObject boss;
    bool isBossHere = false;
    UI_GamePasue pasueMenu;

    // Start is called before the first frame update
    void Start()
    {
        pasueMenu = GameObject.Find("GameManager").GetComponent<UI_GamePasue>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isBossHere)
        {
            boss = GameObject.Find("_TestEnemyBoss");
            if(boss != null)
            {
                isBossHere = true;
            }
        }
        else
        {
            if(boss == null)
            {
                Time.timeScale = 0.0f;
                winMenu.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                pasueMenu.isAvaliable = false;
            }
        }
    }
}
