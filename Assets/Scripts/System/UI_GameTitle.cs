using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_GameTitle : MonoBehaviour
{
    public GameObject[] playerSample;
    Image[] playerSampleImg;
    int curSelection;

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
    }

    public void startGame()
    {
        SceneManager.LoadScene(StaticGameData.scenesName_Game);
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
