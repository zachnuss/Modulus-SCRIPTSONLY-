using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Timer Script
//needs to be eventually implemented into the fly scene
public class Timer_Script : MonoBehaviour
{
    public float time;

    public bool start = false;

    
    void Update()
    {
        if (start)
        {
            time += Time.deltaTime;


        }   
    }


    public int seconds()
    {
        
        return (int)time%60;

    }
    public int minutes()
    {
        return (int)time / 60;
    }
    public void resetTimer()
    {
        time = 0;
    }


}
