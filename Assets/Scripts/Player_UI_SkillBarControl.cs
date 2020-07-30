using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_UI_SkillBarControl : MonoBehaviour
{
    private interface SkillBarSetter
    {
        float skillState { set; }
        Color color { set; }

    }

    private class SpriteSkillBar : SkillBarSetter
    {
        public SpriteRenderer renderer { get; set; }
        public float skillState { set => renderer.transform.localScale = new Vector3(value, 1, 1); }
        public Color color { set => renderer.color = value; }

    }

    private class ImageSkillBar : SkillBarSetter
    {
        public Image img { get; set; }
        public float skillState { set => img.rectTransform.localScale = new Vector3(value, 1, 1); }
        public Color color { set => img.color = value; }
    }

    GameObject player;
    Player_SpecialAbilityActivation playerSkill;
    SkillBarSetter skillBar;

    Color inCD = new Color(0, 90 / 255, 1);
    Color inActived = new Color(1, 200 / 255, 0);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!playerSkill.isActivated)
        {
            float ratio = 1 - Mathf.Min(1, playerSkill.getCurCD() / playerSkill.cd);
            skillBar.skillState = ratio;
            skillBar.color = inCD;
        }
        else
        {
            float ratio = Mathf.Min(1, playerSkill.getCurDuration() / playerSkill.duration);
            skillBar.skillState = ratio;
            skillBar.color = inActived;
        }
        
    }

    public void setPlayer(GameObject player)
    {
        this.player = player;
        playerSkill = player.GetComponent<Player_SpecialAbilityActivation>();
        var sprite = GetComponent<SpriteRenderer>();
        if (sprite != null)
        {
            skillBar = new SpriteSkillBar { renderer = sprite };
        }
        else
        {
            skillBar = new ImageSkillBar { img = GetComponent<Image>() };
        }
    }
}
