using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_GamePasue : MonoBehaviour
{
    public GameObject pasueMenu;
    public bool isPaused;
    public bool isAvaliable;

    public GameObject fadingScreenGO;
    public UI_ScreenFading fadingScreen;
    public AudioSource stageBGM;
    public AudioSource bossBGM;
    bool bgmFading = false;

    public string openSEName;
    AudioSource openSE;
    public string closeSEName;
    AudioSource closeSE;
    
    // Start is called before the first frame update
    void Start()
    {
        openSE = GameObject.Find(openSEName).GetComponent<AudioSource>();
        closeSE = GameObject.Find(closeSEName).GetComponent<AudioSource>();
        if(Time.timeScale != 1.0f)
        {
            Time.timeScale = 1.0f;
        } 
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.C) || Input.GetMouseButtonDown(1)) && isAvaliable)
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                openSE.Play();
                Time.timeScale = 0.0f;
                pasueMenu.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                closeSE.Play();
                Time.timeScale = 1.0f;
                pasueMenu.SetActive(false);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Confined;
            }
        }
        if (bgmFading)
        {
            if (stageBGM.isPlaying)
            {
                stageBGM.volume = Mathf.Max(0, (stageBGM.volume - 0.02f));
            }
            else
            {
                bossBGM.volume = Mathf.Max(0, (bossBGM.volume - 0.02f));
            }
        }
    }

    public void resume()
    {
        isPaused = false;
        pasueMenu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void returnToTitle()
    {
        isPaused = false;
        pasueMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        fadingScreen.changeScene(StaticGameData.scenesName_Title);
        fadingScreenGO.SetActive(true);
        bgmFading = true;
        fadingScreen.inAnimate = true;
    }

    public void restart()
    {
        isPaused = false;
        pasueMenu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        fadingScreen.changeScene(StaticGameData.scenesName_Game);
        fadingScreenGO.SetActive(true);
        bgmFading = true;
        fadingScreen.inAnimate = true;
        
    }
}
