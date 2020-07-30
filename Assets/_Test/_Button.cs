using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class _Button : MonoBehaviour
{
    Button btn;

    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(startBtn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void startBtn()
    {
        SceneManager.LoadScene(0);
    }
}
