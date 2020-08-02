using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner_SpawnWave : MonoBehaviour
/*
 * Enemy spawner script:
 * This script is used to spawn enemy by waves in a stage. 
 * This script can work independently or managed by "Enemy_Spawner_SpawnerManager" script.
 * To use this script, simply add it to an empty object in a scene, and setup the public attribute of the script.
 */
{
    public int waveNum; // This number is only used to determine the waves in editor
    public GameObject[] enemyPrefab; // List of enemy will show up in this wave
    public int[] spawnOrder; // Enemy spawn order, this array's elements are the index number of enemyPrefab array
    public float[] spawnInterval; // Wait time before the enemy spawn
    public TextAsset MovementDataJson; // Json file that use to setup enemy's run route
    P2PMovementDataList movementData;
    public bool isThisWaveInOpt; // Bool to enable/disable this wave

    int totalSpawnNum;
    int curIndex = 0;
    float curInterval = 0;
    bool hasMainSpawner;

    // Start is called before the first frame update
    void Start()
    {
        movementData = JsonUtility.FromJson<P2PMovementDataList>(MovementDataJson.text);
        totalSpawnNum = spawnOrder.Length;
        if (spawnInterval.Length != totalSpawnNum)
        {
            Debug.LogError(gameObject.name + "( Wave No." + waveNum + "): " + "spawn index conflicted, the spawner has been deleted");
            Destroy(gameObject);
        }
        hasMainSpawner = GetComponents<Enemy_Spawner_SpawnerManager>().Length != 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (isThisWaveInOpt)
        {
            curInterval += Time.fixedDeltaTime;
            if (curInterval > spawnInterval[curIndex])
            {
                enemyPrefab[spawnOrder[curIndex]].GetComponent<Enemy_Movement_P2PRoute>().setUpByJson(movementData.list[curIndex]);
                Instantiate(enemyPrefab[spawnOrder[curIndex]]);
                if (curIndex + 1 == totalSpawnNum)
                {
                    if (hasMainSpawner)
                    {
                        turnOff();
                        GetComponent<Enemy_Spawner_SpawnerManager>().goToNextWave();
                    }
                    else
                    {
                        Destroy(gameObject);
                    }
                }
                else
                {
                    curInterval = 0;
                    curIndex = toNextIndex();
                }
            }
        }
    }

    private int toNextIndex()
    {
        return (curIndex + 1) % totalSpawnNum;
    }

    public void turnOn()
    {
        isThisWaveInOpt = true;
        curIndex = 0;
        curInterval = 0;
    }

    public void turnOff()
    {
        isThisWaveInOpt = false;
    }
}
