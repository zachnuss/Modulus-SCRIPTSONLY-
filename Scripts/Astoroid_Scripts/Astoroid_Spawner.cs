using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astoroid_Spawner : MonoBehaviour
{
    [System.Serializable]
    public class Astoroid_Pool
    {
        public string tag;
        public GameObject astoroid;
        public int poolSize;
    }

    public List<Astoroid_Pool> pools;
    Dictionary<string,Queue<GameObject>> astoroidDictonary;

    public GameObject[] sPointArray;

    public float waitTime = 1;

    bool spawn=true;

    // creates out object pool on the scene load to save intantiate time
    private void Awake()
    {
        astoroidDictonary = new Dictionary<string, Queue<GameObject>>();

        foreach (Astoroid_Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.poolSize; i++)
            {
                GameObject newAs = Instantiate(pool.astoroid);
                newAs.SetActive(false);
                objectPool.Enqueue(newAs);
            }
            astoroidDictonary.Add(pool.tag, objectPool);
        }
        
    }
    private void Update()
    {
        if (spawn)
        {
            StartCoroutine(spawnAndWait());
        }

        


    }

    public void spawnAstoroid(string tag)
    {
        GameObject spawnObj = astoroidDictonary[tag].Dequeue();
        spawnObj.SetActive(true);
        spawnObj.transform.position = sPointArray[Random.Range(0, 16)].transform.position;
        spawnObj.transform.parent = null;
        astoroidDictonary[tag].Enqueue(spawnObj);
    }

  IEnumerator spawnAndWait()
    {
        spawn = false;
        Debug.Log("spawning");
        spawnAstoroid("Astoroid");
        
        yield return new WaitForSeconds(waitTime);
        spawn = true;
    }
}
