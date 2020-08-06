using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public TextAsset MovementDataJson; // Json file that use to setup enemy's run route
    public TextAsset FireModeDataJson; // Json file that use to setup enemy's firemode
    P2PMovementDataList movementData;
    FireModeDataList firemodeData;
    public int[] spawnOrder; // Enemy spawn order, this array's elements are the index number of enemyPrefab array
    public int[] movementOrder; // Enemy movement route order, this array's elements are the index number of movementData.list
    public int[] firemodeOrder; // Enemy firemode order, this array's elements are the index number of firemodeData.list
    public float[] spawnInterval; // Wait time before the enemy spawn
    public bool isThisWaveInOpt; // Bool to enable/disable this wave

    int totalSpawnNum;
    int curIndex = 0;
    float curInterval = 0;
    bool hasMainSpawner;
    bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        movementData = JsonUtility.FromJson<P2PMovementDataList>(MovementDataJson.text);
        firemodeData = JsonUtility.FromJson<FireModeDataList>(FireModeDataJson.text);
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
        if (isThisWaveInOpt && !isPaused)
        {
            curInterval += Time.fixedDeltaTime;
            if (curInterval > spawnInterval[curIndex])
            {
                spawn();
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

    private void spawn()
    {
        GameObject enemyUnit = enemyPrefab[spawnOrder[curIndex]];
        enemyUnit.GetComponent<Enemy_Movement_P2PRoute>().setUpByJson(movementData.list[movementOrder[curIndex]]);
        if(enemyUnit.GetComponent<Enemy_FireMode_FireOnP2PRoute>() != null)
        {
            enemyUnit.GetComponent<Enemy_FireMode_FireOnP2PRoute>().setByJson(firemodeData.list[firemodeOrder[curIndex]]);
        }
        else
        {
            enemyUnit.GetComponent<Enemy_FireMode_AimToSnipe>().setByJson(firemodeData.list[firemodeOrder[curIndex]]);
        }
        Instantiate(enemyPrefab[spawnOrder[curIndex]]);
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

    public void setPause(bool p)
    {
        isPaused = p;
    }

    public bool getPause()
    {
        return isPaused;
    }
}
