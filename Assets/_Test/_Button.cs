using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class _Button : MonoBehaviour
{
    Button btn;
    Image[] imgs = new Image[4];
    public int selection = 0;
    Color clr1 = Color.gray;
    Color clr2 = new Color(1, 1, 1);

    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(startBtn);
        imgs[0] = GameObject.Find("Solar").GetComponent<Image>();
        imgs[1] = GameObject.Find("Vortex").GetComponent<Image>();
        imgs[2] = GameObject.Find("Nebula").GetComponent<Image>();
        imgs[3] = GameObject.Find("Stardust").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < 4; i++)
        {
            if(i == selection)
            {
                imgs[i].color = clr2;
            }
            else
            {
                imgs[i].color = clr1;
            }
        }
    }

    void startBtn()
    {
        SceneManager.LoadScene("_TestScene");
    }
}
