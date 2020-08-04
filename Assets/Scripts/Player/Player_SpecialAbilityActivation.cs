using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_SpecialAbilityActivation : MonoBehaviour
// Script for player objects to setup basic skill count down and duration count down
{
    public float cd;
    float curCD = 0;
    public float duration;
    float curDuration = 0;
    bool isReady = false;
    bool isSoundPlayed = false;
    bool isActivated = false;

    // Public bool for other UI related script accessing
    public bool isSPAllowed;

    // Start is called before the first frame update
    void Start()
    {
        curCD = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSPAllowed)
        {
            if (!isActivated && !isReady)
            {
                curCD += Time.deltaTime;
                if (curCD >= cd)
                {
                    isReady = true;
                }
            }
            if(isReady && !isSoundPlayed)
            {
                isSoundPlayed = true;
            }
            else if (isReady && Input.GetKey(KeyCode.Space))
            {
                isReady = false;
                isActivated = true;
                curCD = 0;
                curDuration = duration;
            }
            else if (isActivated)
            {
                curDuration -= Time.deltaTime;
                if (curDuration <= 0)
                {
                    isActivated = false;
                }
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

    public bool getIsReady()
    {
        return isReady;
    }

    public bool getIsActivated()
    {
        return isActivated;
    }
}
