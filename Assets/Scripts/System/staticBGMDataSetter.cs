using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staticBGMDataSetter : MonoBehaviour
{
    public AudioClip[] stageBgmList;
    public AudioClip[] bossBgmList;

    // Start is called before the first frame update
    void Start()
    {
        if(stageBgmList.Length != bossBgmList.Length)
        {
            Debug.LogError("stageBgmList and bossBgmList not match, BGM setup failed.");
        }
        else if (!StaticGameData.isBgmSetted)
        {
            StaticGameData.stageBgmList = stageBgmList;
            StaticGameData.bossBgmList = bossBgmList;
            StaticGameData.isBgmSetted = true;
        }
        Destroy(gameObject);
    }
}
