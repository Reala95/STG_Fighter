using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class System_GameSetup : MonoBehaviour
// Game setup script, use for spawn player object when start or respawn player object when player is destroyed
{
    // Player spawning related
    public GameObject[] fighters = new GameObject[4];
    public GameObject stardustTurret;
    public GameObject[] enemySpawner;
    public UI_GamePasue pauseSetter; // Get Pasue controller for disable pasue menu when spawning player object
    Player_UI_HealthBarControl healthBar;
    Player_UI_SkillBarControl skillBar;
    int selection;

    // Boss fight related
    public GameObject winMenu;
    bool isBossDead = false;

    // Player respaning related
    Enemy_Spawner_SpawnerManager spawners;
    const float resetTime = 3.0f; // Time period of player entering (it must be 3 second)
    float curResetTime = 0;
    bool reseting = false;

    // Life count related
    public GameObject lostMenu;
    public Sprite[] lifeIconSprite;
    Image[] lifeIcon = new Image[6];
    int life = 6;


    // Start is called before the first frame update
    void Start()
    {
        // Set win and pasue menu to staticData for boss fight
        StaticGameData.winMenu = winMenu;
        StaticGameData.pasueSetter = pauseSetter;

        // Load stage spawner for respawning player
        Instantiate(enemySpawner[StaticGameData.stage]);
        spawners = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Enemy_Spawner_SpawnerManager>();

        // Start the initial spawn
        GameObject[] lifeBar = GameObject.FindGameObjectsWithTag("Life");
        for (int i = 0; i < lifeBar.Length; i++)
        {
            lifeIcon[i] = lifeBar[i].GetComponent<Image>();
            lifeIcon[i].sprite = lifeIconSprite[StaticGameData.selection];
        }

        // Start the initial spawn
        selection = StaticGameData.selection;
        healthBar = GameObject.Find("ActualHealth").GetComponent<Player_UI_HealthBarControl>();
        skillBar = GameObject.Find("ActualSkillCD").GetComponent<Player_UI_SkillBarControl>();
        spawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (isBossDead)
        {
            Player_MovemovementControl player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_MovemovementControl>();
            player.setBossDead(isBossDead);
            player.isAllowMoving = false;
            isBossDead = false;
            
        }
        else if (GameObject.FindGameObjectsWithTag("Player").Length == 0 && !reseting)
        {
            life--;
            curResetTime = 0;
            reseting = true;
            spawners.setPause(true);
            if (life >= 0)
            {
                lifeIcon[life].color = Color.black;
                spawnPlayer();
            }
            else
            {
                pauseSetter.isAvaliable = false;
                Time.timeScale = 0.0f;
                lostMenu.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }

        }
        else if (reseting)
        {
            curResetTime += Time.fixedDeltaTime;
            if (curResetTime > resetTime)
            {
                reseting = false;
                spawners.setPause(false);
            }
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

    public void setBossDead(bool isBossDead)
    {
        this.isBossDead = isBossDead;
    }
}
