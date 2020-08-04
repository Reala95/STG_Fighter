using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _TestEnemyWeapon : MonoBehaviour
{
    public GameObject enemy;
    public GameObject bullet;
    double[] degrees = { 30, 150, 270 };
    public bool isFireAllowed;
    public float firstFire;
    Common_Bullet bulletData;
    public float count;
    float curCount = 0;

    GameObject winMenu;
    UI_GamePasue pauseSetter;
    AudioSource stageBGM;
    AudioSource BossBGM;
    
        // Start is called before the first frame update
    void Start()
    {
        winMenu = StaticGameData.winMenu;
        pauseSetter = StaticGameData.pasueSetter;
        bulletData = bullet.GetComponent<Common_Bullet>();
        stageBGM = GameObject.FindGameObjectWithTag("bgmPlayer/Stage").GetComponent<AudioSource>();
        stageBGM.Stop();
        BossBGM = GameObject.FindGameObjectWithTag("bgmPlayer/Boss").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (!isFireAllowed)
        {
            firstFire -= Time.fixedDeltaTime;
            if(firstFire <= 0)
            {
                isFireAllowed = true;
                BossBGM.Play();
            }
        }
        else if (isFireAllowed)
        {
            curCount -= Time.fixedDeltaTime;
            if (curCount <= 0)
            {
                Fire();
                curCount = count;
            }
        }

    }

    private void Fire()
    {
        for(int i = 0; i < 3; i++)
        {
            bulletData.shootDegree = degrees[i];
            bullet.transform.position = enemy.transform.position;
            Instantiate(bullet);
            degrees[i] = (degrees[i] + 5) % 360;
        }
    }

    private void OnDestroy()
    {
        pauseSetter.isAvaliable = false;
        Time.timeScale = 0.0f;
        winMenu.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
