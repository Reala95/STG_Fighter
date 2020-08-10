using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSS_Common_CallWinMenu : MonoBehaviour
{
    System_GameSetup manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<System_GameSetup>();
    }

    private void OnDestroy()
    {
        manager.setBossDead(true);
    }
}
