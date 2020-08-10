using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class System_BackGroundRolling : MonoBehaviour
{
    public GameObject background;
    public float rollingSpeed;
    float curRollingTime1 = 0;
    float curRollingTime2 = 0;
    public Vector3 startPoint;
    public Vector3 transPoint;
    public Vector3 endPoint;
    public Vector3 newSpawnPoint;
    bool inPhase1 = false;
    bool inPhase2 = false;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPoint;
        inPhase1 = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (inPhase1)
        {
            transform.position = Vector3.MoveTowards(startPoint, transPoint, rollingSpeed * curRollingTime1);
            curRollingTime1 += Time.deltaTime;
            if (transform.position == transPoint)
            {
                Instantiate(background, newSpawnPoint, Quaternion.identity);
                inPhase1 = false;
                inPhase2 = true;
            }
        }
        else if (inPhase2)
        {
            transform.position = Vector3.MoveTowards(transPoint, endPoint, rollingSpeed * curRollingTime2);
            curRollingTime2 += Time.deltaTime;
            if(transform.position == endPoint)
            {
                Destroy(gameObject);
            }
        }
    }
}
