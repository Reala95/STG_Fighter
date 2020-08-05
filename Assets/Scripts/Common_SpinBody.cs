using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common_SpinBody : MonoBehaviour
// Script for any object who need to spin
{
    public Vector3 rotating;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotating);
    }
}
