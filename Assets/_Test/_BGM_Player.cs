using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _BGM_Player : MonoBehaviour 
{ 

    // Start is called before the first frame update

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
