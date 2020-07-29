using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_SpecialAbilityActivation : MonoBehaviour
{
    public float cd;
    float curCD = 0;
    public float duration;
    float curDuration = 0;
    public bool isReady = false;
    public bool isActivated = false;

    // Start is called before the first frame update
    void Start()
    {
        curCD = cd;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActivated && !isReady)
        {
            curCD -= Time.deltaTime;
            if(curCD <= 0)
            {
                isReady = true;
            }
        }
        else if (isReady && Input.GetKey(KeyCode.Space))
        {
            isReady = false;
            isActivated = true;
            curCD = cd;
            curDuration = duration;
        } 
        else if (isActivated)
        {
            curDuration -= Time.deltaTime;
            if(curDuration <= 0)
            {
                isActivated = false;
            }
        }
    }

    public float getCurCD()
    {
        return curCD;
    }

    public float getCurDuration()
    {
        return curDuration;
    }
}
