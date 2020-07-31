using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_DropItemWhenDie : MonoBehaviour
{
    public GameObject[] item;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Drop()
    {
        foreach(GameObject i in item)
        {
            Instantiate(i, transform.position, Quaternion.identity);
        }
    }
}
