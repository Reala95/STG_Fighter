using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_bgmPlayerLoad : MonoBehaviour
{
    public bool isBossBGM;
    public AudioClip defaultBgm;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (isBossBGM)
        {
            if (StaticGameData.bossBgmList == null)
            {
                audioSource.clip = defaultBgm;
            }
            else
            {
                audioSource.clip = StaticGameData.bossBgmList[StaticGameData.stage];
            }
            audioSource.Stop();
        }
        else
        {
            if (StaticGameData.stageBgmList == null)
            {
                audioSource.clip = defaultBgm;
            }
            else
            {
                audioSource.clip = StaticGameData.stageBgmList[StaticGameData.stage];
            }
            audioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
