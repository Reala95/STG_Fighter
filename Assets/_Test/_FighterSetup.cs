using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _FighterSetup : MonoBehaviour
{
    public int fighterSelection;
    public GameObject[] fighters = new GameObject[4];
    public GameObject stardustTurret;

    Player_UI_HealthBarControl healthBar;
    Player_UI_SkillBarControl skillBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GameObject.Find("ActualHealth").GetComponent<Player_UI_HealthBarControl>();
        skillBar = GameObject.Find("ActualSkillCD").GetComponent<Player_UI_SkillBarControl>();
        fighterSelection = StaticGameData.selection;
        Instantiate(fighters[fighterSelection]);
        if(fighterSelection == 3)
        {
            Instantiate(stardustTurret);
        }
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        healthBar.setPlayer(player);
        skillBar.setPlayer(player);
        //Destroy(GameObject.FindGameObjectWithTag("FakePlayer"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
