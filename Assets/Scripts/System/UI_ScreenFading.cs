using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_ScreenFading : MonoBehaviour
{
    Image img;
    Color imgClr = Color.black;
    float opacity = 1f;
    string sceneName;

    bool fadeIn = true;
    public bool inAnimate = true;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        imgClr.a = opacity;
    }

    // Update is called once per frame
    void Update()
    {
        if (inAnimate)
        {
            if (fadeIn)
            {
                if (opacity == 0)
                {
                    inAnimate = false;
                    fadeIn = !fadeIn;
                    gameObject.SetActive(false);
                }
                if(Time.timeScale != 0)
                {
                    opacity = Mathf.Max(0, (opacity - Time.deltaTime));
                }
                else
                {
                    opacity = Mathf.Max(0, (opacity - 0.02f));
                }
                imgClr.a = opacity;
                img.color = imgClr;
            }
            else
            {
                if (opacity == 1)
                {
                    inAnimate = false;
                    fadeIn = !fadeIn;
                    SceneManager.LoadScene(sceneName);
                }
                if (Time.timeScale != 0)
                {
                    opacity = Mathf.Min(1, (opacity + Time.deltaTime));
                }
                else
                {
                    opacity = Mathf.Min(1, (opacity + 0.02f));
                }
                imgClr.a = opacity;
                img.color = imgClr;
            }
        }
    }

    public void changeScene(string sceneName)
    {
        inAnimate = true;
        this.sceneName = sceneName;
    }
}
