using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Media;
using UnityEngine;
using UnityEngine.UI;

public class Player_UI_HealthBarControl : MonoBehaviour
{
    private interface HealthBarSetter
    {
        float NormalizedHP { set; }
        Color Color { set; }
    }

    private class SpriteHealthBar : HealthBarSetter
    {
        public SpriteRenderer Renderer { get; set; }
        public float NormalizedHP { set => Renderer.transform.localScale = new Vector3(value, 1, 1); }
        public Color Color { set => Renderer.color = value; }
    }

    private class ScrollBarHealthBar : HealthBarSetter
    {
        public Scrollbar Scrollbar { get; set; }
        public float NormalizedHP { set => Scrollbar.size = value; }
        public Color Color
        {
            set
            {
                var newColors = Scrollbar.colors;
                newColors.disabledColor = value;
                Scrollbar.colors = newColors;
            }
        }
    }

    public AnimationCurve redCurve;
    public AnimationCurve greenCurve;
    public AnimationCurve blueCurve;
    Common_HP playerHP;
    HealthBarSetter healthBar;

    // Start is called before the first frame update
    void Start()
    {
        playerHP = GameObject.FindGameObjectWithTag("Player").GetComponent<Common_HP>();
        var sprite = GetComponent<SpriteRenderer>();
        if(sprite != null)
        {
            healthBar = new SpriteHealthBar { Renderer = sprite };
        }
        else
        {
            var scrollBar = GetComponent<Scrollbar>();
            scrollBar.interactable = false; // user cannot edit scrollbar
            scrollBar.value = 0; // 0 means align to left
            healthBar = new ScrollBarHealthBar { Scrollbar = scrollBar };
        }
    }

    // Update is called once per frame
    void Update()
    {
        float ratio = (float)playerHP.getCurrentHP() / playerHP.getMaxHP();
        healthBar.NormalizedHP = ratio;

        float r = redCurve.Evaluate(ratio);
        float g = greenCurve.Evaluate(ratio);
        float b = blueCurve.Evaluate(ratio);
        healthBar.Color = new Color(r, g, b);
    }
}

