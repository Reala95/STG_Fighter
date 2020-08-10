using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSS_Stage1_CrashHint : MonoBehaviour
{
    public Vector3 targetPos;
    public AnimationCurve heightCurve;
    public AnimationCurve opacityCurve;
    public float growRatio;
    public float fadeRatio;

    SpriteRenderer sr;
    float opacity = 0.75f;
    Color spriteColor;
    float height = 1;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        spriteColor = sr.color;
        spriteColor.a = opacity;
        sr.color = spriteColor;
        Quaternion q = Quaternion.AngleAxis(getTargetAngle() - 90, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if(height < 50)
        {
            height = Mathf.Min(50, height + growRatio * Time.deltaTime);
            sr.size = new Vector2(1, 50 * heightCurve.Evaluate(height / 50));
        }
        else if (opacity > 0)
        {
            opacity = Mathf.Max(0, opacity - fadeRatio * Time.deltaTime);
            spriteColor.a = opacityCurve.Evaluate(opacity);
            sr.color = spriteColor;
        } 
        else if (opacity == 0)
        {
            Destroy(gameObject);
        }
    }

    float getTargetAngle()
    {
        Vector3 v = targetPos - transform.position;
        return Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
    }
}
