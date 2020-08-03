using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Reset : MonoBehaviour
{
    Player_UI_HealthBarControl healthBar;
    Player_UI_SkillBarControl skillBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GameObject.Find("ActualHealth").GetComponent<Player_UI_HealthBarControl>();
        skillBar = GameObject.Find("ActualSkillCD").GetComponent<Player_UI_SkillBarControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        healthBar.setInOpt(false);
        skillBar.setInOpt(false);
    }
}
