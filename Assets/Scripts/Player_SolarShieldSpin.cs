using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_SolarShieldSpin : MonoBehaviour
{
    public Vector3 rotating;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotating);
    }
}
