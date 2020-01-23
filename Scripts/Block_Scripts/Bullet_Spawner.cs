using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Spawner : MonoBehaviour
{
    [System.Serializable]
    public class Bullet_Pool
    {
        public string tag;
        public GameObject bullet;
        public int poolSize;
    }

    public List<Bullet_Pool> pools;
    public Dictionary<string, Queue<GameObject>> bulletDictonary;

    public static Bullet_Spawner S;
    

    // creates out object pool on the scene load to save intantiate time
    private void Awake()
    {
        S = this;
        bulletDictonary = new Dictionary<string, Queue<GameObject>>();

        foreach (Bullet_Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.poolSize; i++)
            {
                GameObject newAs = Instantiate(pool.bullet);
                newAs.SetActive(false);
                objectPool.Enqueue(newAs);
            }
            bulletDictonary.Add(pool.tag, objectPool);
        }

    }
    
}
