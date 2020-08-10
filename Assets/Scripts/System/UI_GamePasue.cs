using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_GamePasue : MonoBehaviour
{
    public GameObject pasueMenu;
    public bool isPaused;
    public bool isAvaliable;

    public string openSEName;
    AudioSource openSE;
    public string closeSEName;
    AudioSource closeSE;
    
    // Start is called before the first frame update
    void Start()
    {
        openSE = GameObject.Find(openSEName).GetComponent<AudioSource>();
        closeSE = GameObject.Find(closeSEName).GetComponent<AudioSource>();
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
    }

    public void resume()
    {
        isPaused = false;
        Time.timeScale = 1.0f;
        pasueMenu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void returnToTitle()
    {
        isPaused = false;
        Time.timeScale = 1.0f;
        pasueMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(StaticGameData.scenesName_Title);
    }

    public void restart()
    {
        isPaused = false;
        Time.timeScale = 1.0f;
        pasueMenu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene(StaticGameData.scenesName_Game);
    }
}
