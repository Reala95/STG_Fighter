using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_UI_SkillBarControl : MonoBehaviour
{
    Player_SpecialAbilityActivation playerSkill;

    // Start is called before the first frame update
    void Start()
    {
        playerSkill = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_SpecialAbilityActivation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerSkill.isActivated)
        {
            float ratio = 1 - Mathf.Min(1, playerSkill.getCurCD() / playerSkill.cd);
            transform.localScale = new Vector3(ratio, 1, 1);
        }
        else
        {
            float ratio = Mathf.Min(1, playerSkill.getCurDuration() / playerSkill.duration);
            transform.localScale = new Vector3(ratio, 1, 1);
        }
        
    }
}
