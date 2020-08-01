using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _TestSpawner : MonoBehaviour
{
    public TextAsset j;
    P2PMovementData data;
    // Start is called before the first frame update
    void Start()
    {
        string json = j.ToString();
        data = JsonUtility.FromJson<P2PMovementData>(json);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
