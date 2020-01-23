using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Block : _Block
{
    public GameObject shootPt;
    bool shoot = true;
    private void Awake()
    {
        setBlockStats(50, 0, 1, 1,0);
    }

    private void Update()
    { 
        if(Scene_Manager.S.stateOfGame == GameState.playState)
        {
            if (shoot)
            {
                StartCoroutine(fire());
            }
        }



    }


    IEnumerator fire()
    {
        shoot = false;
        shootBullet();
        yield return new WaitForSeconds(0.5f);
        shoot = true;
    }

    void shootBullet()
    {
        string tag = "bullet";
        GameObject spawnObj = Bullet_Spawner.S.bulletDictonary[tag].Dequeue();
        spawnObj.SetActive(true);
        spawnObj.transform.position = shootPt.transform.position;
        Bullet_Spawner.S.bulletDictonary[tag].Enqueue(spawnObj);


    }
}
