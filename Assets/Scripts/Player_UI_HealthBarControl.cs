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
        Color color { set; }
    }

    private class SpriteHealthBar : HealthBarSetter
    {
        public SpriteRenderer renderer { get; set; }
        public float NormalizedHP { set => renderer.transform.localScale = new Vector3(value, 1, 1); }
        public Color color { set => renderer.color = value; }
    }

    private class ImageHealthBar : HealthBarSetter
    {
        public Image img { get; set; }
        public float NormalizedHP { set => img.rectTransform.localScale = new Vector3(value, 1, 1); }
        public Color color { set => img.color = value; }
    }

    public AnimationCurve redCurve;
    public AnimationCurve greenCurve;
    public AnimationCurve blueCurve;
    Common_HP playerHP;
    HealthBarSetter healthBar;

    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.FindGameObjectsWithTag("Player").Length == 0)
        {
            Destroy(gameObject);
        }
        else
        {
            playerHP = GameObject.FindGameObjectWithTag("Player").GetComponent<Common_HP>();
            var sprite = GetComponent<SpriteRenderer>();
            if (sprite != null)
            {
                healthBar = new SpriteHealthBar { renderer = sprite };
            }
            else
            {
                healthBar = new ImageHealthBar { img = GetComponent<Image>() };
            }
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
        healthBar.color = new Color(r, g, b);
    }
}

