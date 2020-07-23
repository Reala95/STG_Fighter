using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Media;
using UnityEngine;

public class Player_UI_HealthBarControl : MonoBehaviour
{
    public AnimationCurve redCurve;
    public AnimationCurve greenCurve;
    public AnimationCurve blueCurve;
    Common_HP playerHP;
    SpriteRenderer healthBarRenderer;

    // Start is called before the first frame update
    void Start()
    {
        playerHP = GameObject.FindGameObjectWithTag("Player").GetComponent<Common_HP>();
        healthBarRenderer = transform.GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float ratio = (float) playerHP.getCurrentHP() / playerHP.getMaxHP();
        transform.localScale = new Vector3(ratio, 1, 1);
        float r = redCurve.Evaluate(Math.Min(1, (1 - ratio) * 2));
        float g = greenCurve.Evaluate(Math.Min(1, ratio * 2));
        float b = 0;
        healthBarRenderer.color = new Color(r, g, b);
    }
}
