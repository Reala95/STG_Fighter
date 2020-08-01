using System.Linq;
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
        public float NormalizedHP { set => renderer.transform.localScale = new Vector3(value, 1.0f, 1.0f); }
        public Color color { set => renderer.color = value; }
    }

    private class ImageHealthBar : HealthBarSetter
    {
        public Image img { get; set; }
        public float NormalizedHP { set => img.rectTransform.localScale = new Vector3(value, 1.0f, 1.0f); }
        public Color color { set => img.color = value; }
    }

    GameObject player;
    Common_HP playerHP;
    HealthBarSetter healthBar;

    public AnimationCurve redCurve;
    public AnimationCurve greenCurve;
    public AnimationCurve blueCurve;

    bool isInOpt = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("FakePlayer");
        playerHP = player.GetComponent<Common_HP>();
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

    // Update is called once per frame
    void Update()
    {
            float ratio = (float)playerHP.getCurrentHP() / playerHP.getMaxHP();
            healthBar.NormalizedHP = ratio;

            float r = redCurve.Evaluate(ratio);
            float g = greenCurve.Evaluate(ratio);
            healthBar.color = new Color(r, g, 0);
    }

    public void setPlayer(GameObject player)
    {
        this.player = player;
        playerHP = player.GetComponent<Common_HP>();
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

    public void setBarRatio(float ratio)
    {
        healthBar.NormalizedHP = ratio;
        float r = redCurve.Evaluate(ratio);
        float g = greenCurve.Evaluate(ratio);
        healthBar.color = new Color(r, g, 0);
    }

    public void setInOpt(bool isInOpt)
    {
        this.isInOpt = isInOpt;
    }
}

