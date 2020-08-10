using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BOSS_Stage1_BigEaterControl : MonoBehaviour
{
    public GameObject hint;
    public float waitTime;
    float curWaitTime = 0;
    public float hintWaitTime;
    public float bodyInterval;
    float curBodyInterval = 0;
    public Vector3 initStartPos;
    public Vector3 initEndPos;

    AudioSource stageBGM, bossBGM;
    Enemy_FireMode_FireOnP2PRoute[] bodysFire;
    BOSS_Stage1_BigEaterBodyPart[] bodysData;
    Vector3[] route = new Vector3[2];
    int curRoute = -1;
    int curBodyPart = 0;
    bool onInit = false;
    bool onWait = false;
    bool onMove = false;
    bool firstShow = true;

    // Start is called before the first frame update
    void Start()
    {
        stageBGM = GameObject.FindGameObjectWithTag("bgmPlayer/Stage").GetComponent<AudioSource>();
        bossBGM = GameObject.FindGameObjectWithTag("bgmPlayer/Boss").GetComponent<AudioSource>();
        bodysFire = GetComponentsInChildren<Enemy_FireMode_FireOnP2PRoute>();
        bodysData = GetComponentsInChildren<BOSS_Stage1_BigEaterBodyPart>();
        curWaitTime = waitTime;
        curBodyInterval = bodyInterval;
        route[0] = initStartPos;
        route[1] = initEndPos;
        onInit = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (onInit)
        {
            stageBGM.volume = Mathf.Max(0, stageBGM.volume - Time.fixedDeltaTime);
            if (stageBGM.volume == 0)
            {
                stageBGM.Stop();
                onInit = false;
                onWait = true;
                hint.GetComponent<BOSS_Stage1_CrashHint>().targetPos = route[1];
                Instantiate(hint, route[0], Quaternion.identity);
            }
        }
        else if (onWait)
        {
            if (firstShow && !bossBGM.isPlaying && curRoute != -1)
            {
                bossBGM.Play();
            }
            curWaitTime -= Time.fixedDeltaTime;
            if (curWaitTime <= 0)
            {
                onWait = false;
                onMove = true;
            }
        }
        else if (onMove)
        {
            if(bodysData[curBodyPart] != null)
            {
                curBodyInterval -= Time.fixedDeltaTime;
                if (curBodyInterval <= 0)
                {
                    bodysData[curBodyPart].setRoute(route[0], route[1]);
                    curBodyPart++;
                    curBodyInterval = bodyInterval;
                }
                if (firstShow && curRoute != -1)
                {
                    foreach (Enemy_FireMode_FireOnP2PRoute fire in bodysFire)
                    {
                        fire.isFireAllowed = true;
                    }
                    firstShow = false;
                }
            }
            else
            {
                curBodyPart++;
            }
            if(curBodyPart == bodysData.Length)
            {
                curBodyPart = 0;
                goToNextRoute();
                setNewRoute();
                hint.GetComponent<BOSS_Stage1_CrashHint>().targetPos = route[1];
                Instantiate(hint, route[0], Quaternion.identity);
                curWaitTime = waitTime;
                onWait = true;
                onMove = false;
            }
        }
    }

    private void setNewRoute()
    {
        switch (curRoute)
        {
            case 0:
                route[0] = new Vector3(Random.Range(-7.0f, 0.0f), -6.5f, 0);
                route[1] = new Vector3(Random.Range(0.0f, 7.0f), 6.5f, 0);
                break;
            case 1:
                route[0] = new Vector3(Random.Range(-7.0f, 0.0f), 6.5f, 0);
                route[1] = new Vector3(Random.Range(0.0f, 7.0f), -6.5f, 0);
                break;
            case 2:
                route[0] = new Vector3(-9.5f, Random.Range(0.0f, 4.0f), 0);
                route[1] = new Vector3(9.5f, Random.Range(-4.0f, 0.0f), 0);
                break;
            case 3:
                route[0] = new Vector3(9.5f, Random.Range(0.0f, 4.0f), 0);
                route[1] = new Vector3(-9.5f, Random.Range(-4.0f, 0.0f), 0);
                break;
        }
    }

    private void goToNextRoute()
    {
        curRoute = (curRoute + 1) % 4;
    }

    private Vector3 getRoute1()
    {
        return route[1];
    }
}
