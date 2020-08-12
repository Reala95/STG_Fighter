using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_GameTitle : MonoBehaviour
{
    public GameObject[] playerSample;
    public GameObject fadingScreenGO;
    public AudioSource titleBGM;
    public UI_ScreenFading fadingScreen;
    Image[] playerSampleImg;
    int curSelection;
    bool bgmFading = false;

    // Start is called before the first frame update
    void Start()
    {
        curSelection = StaticGameData.selection;
        playerSampleImg = new Image[playerSample.Length];
        for(int i = 0; i < playerSample.Length; i++)
        {
            playerSampleImg[i] = playerSample[i].GetComponent<Image>();
            playerSampleImg[i].color = Color.gray;
        }
        playerSampleImg[curSelection].color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if (curSelection != StaticGameData.selection)
        {
            playerSampleImg[curSelection].color = Color.gray;
            playerSampleImg[StaticGameData.selection].color = Color.white;
            curSelection = StaticGameData.selection;
        }
        if (bgmFading)
        {
            titleBGM.volume = Mathf.Max(0, (titleBGM.volume - Time.deltaTime));
        }
    }

    public void startGame()
    {
        bgmFading = true;
        fadingScreenGO.SetActive(true);
        fadingScreen.changeScene(StaticGameData.scenesName_Game);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void selectThis(int i)
    {
        StaticGameData.selection = i;
    }
}
