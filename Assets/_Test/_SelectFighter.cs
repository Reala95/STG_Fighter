using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _SelectFighter : MonoBehaviour
{
    public int selectionNum;
    _Button startBtn;
    Button btn;

    // Start is called before the first frame update
    void Start()
    {
        startBtn = GameObject.Find("Button").GetComponent<_Button>();
        btn = GetComponent<Button>();
        btn.onClick.AddListener(selectThis);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void selectThis()
    {
        startBtn.selection = selectionNum;
        StaticGameData.selection = selectionNum;
    }
}
