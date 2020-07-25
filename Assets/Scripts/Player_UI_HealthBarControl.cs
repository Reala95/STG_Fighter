using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    private class ImageHealthBar : HealthBarSetter
    {
        public Image Image { get; set; }
        public float NormalizedHP { set => Image.rectTransform.localScale = new Vector3(value, 1, 1); }
        public Color Color { set => Image.color = value; }
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
            var childrenImage = GetComponentsInChildren<Image>()
                .First(image => image.gameObject != this.gameObject);
            healthBar = new ImageHealthBar { Image = childrenImage };
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

