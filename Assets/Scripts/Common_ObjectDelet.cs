using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common_ObjectDelet : MonoBehaviour
// Script for empty parent object to self deleted when children objects are all destroyed
{
    private void FixedUpdate()
    {
        if(transform.childCount == 0)
        {
            Destroy(gameObject);
        }
    }
}
