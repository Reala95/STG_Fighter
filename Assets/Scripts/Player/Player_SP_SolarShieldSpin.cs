using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_SP_SolarShieldSpin : MonoBehaviour
// Script for Solar Shield skill to let shield sprite spinning
// PS. This script should assign to the SolarShields sub-prefab object
{
    public Vector3 rotating;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotating);
    }
}
