using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE_PlayerSoundManager : MonoBehaviour
{
    AudioSource[] SE;
    public int
        solarFire = 0,
        solarShield = 1,
        vortexFire = 2,
        vortexBlast = 3,
        nebulaFire = 4,
        nebulaSnipe = 5,
        stardustFire = 6,
        stardustTurret = 7
        ;

    // Start is called before the first frame update
    void Start()
    {
        SE = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playerSound (int index)
    {
        SE[index].Play();
    }
}
