using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour
{
    private interface aiSetter
    {
        GameObject enemy { get; set; }
    }

    private class pointListSetter : aiSetter
    {
        public GameObject enemy { get; set; }
        public float[] moveAngleList { set => enemy.GetComponent<Enemy_Movement_PointList>().moveAngleList = value; }
        public float[] moveTimeList { set => enemy.GetComponent<Enemy_Movement_PointList>().moveTimeList = value; }
        public float[] waitTimeList { set => enemy.GetComponent<Enemy_Movement_PointList>().waitTimeList = value; }
        public float linearVelocity { set => enemy.GetComponent<Enemy_Movement_PointList>().linearVelocity = value; }
        public bool rotateToNextBeforeMove { set => enemy.GetComponent<Enemy_Movement_PointList>().rotateToNextBeforeMove = value; }
        public bool rotateToNextWhileWaiting { set => enemy.GetComponent<Enemy_Movement_PointList>().rotateToNextWhileWaiting = value; }
    }

    public GameObject[] enemyList;
    public int[/*Wave Number*/][/*Index of the enemy in list*/] wave; 
    public int[] waveOrder; // The order of enemy wave 
    public float[/*Wave Number*/] spawnIntervalInWave; // The time between enemy spawn in the specify wave
    public float spawnIntervalBetweenWave;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
