using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UI_PlayerDescription : MonoBehaviour
{
    public TextAsset descriptionEN;
    public TextAsset descriptionCN;
    string[] desEN;
    string[] desCN;
    Text text;
    public int curLang = 0; // 0 = EN; 1 = CN
    int curSelection = 0;

    public Text btn_Txt;

    void Start()
    {
        string rawEN = descriptionEN.text;
        desEN = rawEN.Split(';');
        string rawCN = descriptionCN.text;
        desCN = rawCN.Split(';');
        text = GetComponent<Text>();
        curSelection = StaticGameData.selection;
        text.text = desEN[curSelection];
    }

    // Update is called once per frame
    void Update()
    {
        if(curSelection != StaticGameData.selection)
        {
            curSelection = StaticGameData.selection;
            switch (curLang)
            {
                case 0:
                    text.text = desEN[curSelection];
                    break;

                case 1:
                    text.text = desCN[curSelection];
                    break;
            }
        }
    }

    public void changeLang()
    {
        curLang = (curLang + 1) % 2;
        switch (curLang)
        {
            case 0:
                text.text = desEN[curSelection];
                btn_Txt.text = "中文";
                break;

            case 1:
                text.text = desCN[curSelection];
                btn_Txt.text = "English";
                break;
        }
    }
}
