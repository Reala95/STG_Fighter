using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy_Spawner_SpawnerManager : MonoBehaviour
/*
 * Enemy wave manager script:
 * This script is use to manage "Enemy_Spawner_SpawnWave" within the same object.
 */
{
    public int[] waveOrder; // Wave spawn order
    public float[] waveInterval; // Wait time before wave spawn
    public bool destroyWhenDone; 

    Enemy_Spawner_SpawnWave[] spawnWaves;
    int curWave = 0;
    float curInterval = 0;
    bool waveInopt = false;
    bool isPaused = false;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnWaves = GetComponents<Enemy_Spawner_SpawnWave>();
        foreach(Enemy_Spawner_SpawnWave w in spawnWaves)
        {
            if (w.isThisWaveInOpt)
            {
                Debug.LogError(gameObject.name + ": wave No." + w.waveNum + " unexpected in opt, this gameObject is deleted");
                Destroy(gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (curWave == waveOrder.Length)
        {
            Debug.Log(gameObject.name + ": All waves are done.");
            if (destroyWhenDone)
            {
                Debug.Log(gameObject.name + ": Deleting spawner.");
                Destroy(gameObject);
            }
        } 
        else if (isPaused)
        {
            if(isPaused != spawnWaves[waveOrder[curWave]].getPause())
            {
                spawnWaves[waveOrder[curWave]].setPause(isPaused);
            }
        }
        else if (!isPaused && waveInopt)
        {
            if (isPaused != spawnWaves[waveOrder[curWave]].getPause())
            {
                spawnWaves[waveOrder[curWave]].setPause(isPaused);
            }
        }
        else if (!isPaused && !waveInopt)
        {
            if (isPaused != spawnWaves[waveOrder[curWave]].getPause())
            {
                spawnWaves[waveOrder[curWave]].setPause(isPaused);
            }
            curInterval += Time.fixedDeltaTime;
            if (curInterval > waveInterval[curWave])
            {
                spawnWaves[waveOrder[curWave]].turnOn();
                waveInopt = true;
            }
        }
    }

    public void goToNextWave()
    {
        curWave++;
        curInterval = 0;
        waveInopt = false;
    }

    public void setPause(bool p)
    {
        isPaused = p;
    }
}
