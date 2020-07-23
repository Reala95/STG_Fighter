using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common_ObjectDelet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(transform.GetChildCount() == 0)
        {
            Destroy(gameObject);
        }
    }
}
