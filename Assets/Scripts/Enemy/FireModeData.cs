using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FireModeData
{
    public int index;
    public float firstShotWaitTime;
    public float reloadTime; 
    public int bulletClip;
    public int clipAmount;
    public float fireInterval;
    public bool isFireAllowed;
}
