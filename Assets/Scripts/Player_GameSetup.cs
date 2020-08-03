using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_GameSetup : MonoBehaviour
{
    public int selection;
    public GameObject[] fighters = new GameObject[4];
    public GameObject stardustTurret;

    Player_UI_HealthBarControl healthBar;
    Player_UI_SkillBarControl skillBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GameObject.Find("ActualHealth").GetComponent<Player_UI_HealthBarControl>();
        skillBar = GameObject.Find("ActualSkillCD").GetComponent<Player_UI_SkillBarControl>();
        selection = StaticGameData.selection;
        spawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Player").Length == 0)
        {
            spawnPlayer();
        }
    }

    void spawnPlayer()
    {
        Instantiate(fighters[selection]);
        if (selection == 3)
        {
            Instantiate(stardustTurret);
        }
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        healthBar.setPlayer(player);
        skillBar.setPlayer(player);
    }
}
