using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spaner_WaveSpwaner : MonoBehaviour
{
    public GameObject[] enemyObjects;
    public int[] spawnOrder;
    public float[] spawnInterval;
    public TextAsset MovementDataJson;
    P2PMovementDataList movementData;

    int totalSpawnNum;
    int curIndex = 0;
    float curInterval = 0;

    // Start is called before the first frame update
    void Start()
    {
        movementData = JsonUtility.FromJson<P2PMovementDataList>(MovementDataJson.text);
        totalSpawnNum = spawnOrder.Length;
        if(spawnInterval.Length != totalSpawnNum || movementData.list.Length != totalSpawnNum)
        {
            Debug.LogError(gameObject.name + ": spwan number not match, this gameObject has been deleted.");
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        curInterval += Time.fixedDeltaTime;
        if(curInterval > spawnInterval[curIndex])
        {
            enemyObjects[spawnOrder[curIndex]].GetComponent<Enemy_Movement_P2PRoute>().setUpByJson(movementData.list[curIndex]);
            Instantiate(enemyObjects[spawnOrder[curIndex]]);
            curIndex++;
            if(curIndex == totalSpawnNum)
            {
                Destroy(gameObject);
            }
            curInterval = 0;
        }
    }
}
