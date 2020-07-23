using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_UI_HealthBarControl : MonoBehaviour
{
    public AnimationCurve redCurve;
    public AnimationCurve greenCurve;
    public AnimationCurve blueCurve;
    GameObject healthBar;
    SpriteRenderer healthBarRenderer;
    GameObject player;
    Common_HP playerHP;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GameObject.Find("BarAnchor");
        healthBarRenderer = healthBar.GetComponentInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHP = GameObject.FindGameObjectWithTag("Player").GetComponent<Common_HP>();
    }

    // Update is called once per frame
    void Update()
    {
        var ratio = (float)playerHP.getCurrentHP() / playerHP.getMaxHP();
        healthBar.transform.localScale = new Vector3(ratio, 1, 1);
        float r = redCurve.Evaluate(ratio);
        float g = greenCurve.Evaluate(ratio);
        float b = blueCurve.Evaluate(ratio);
        healthBarRenderer.color = new Color(r, g, b);
    }

    private void FixedUpdate()
    {
        
    }
}
