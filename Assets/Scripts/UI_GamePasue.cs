using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_GamePasue : MonoBehaviour
{
    public GameObject pasueMenu;
    public bool isPaused;
    public bool isAvaliable;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && isAvaliable)
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                Time.timeScale = 0.0f;
                pasueMenu.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
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
        Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene(StaticGameData.scenesName_Title);
    }
}
