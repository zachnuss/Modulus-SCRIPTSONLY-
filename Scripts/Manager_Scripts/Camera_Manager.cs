using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Manager : MonoBehaviour
{
    public Camera main;
    public Vector3 garageCameraPos = new Vector3(0, 20, 0);
    public Vector3 startPos;
    public Vector3 nextPos;
    public float startTime;
    public float speed= 20f;
    private float distance, partOfDist, distOverT;
    public bool Lerp=false,setStartTime=false;
    private void Awake()
    {
        startPos = garageCameraPos;
        
    }
    private void Update()
    {
        
        if (Lerp)
        {
            
            if (setStartTime)
            {
                startTime = Time.time;
                setStartTime = false;
                distance = Vector3.Distance(startPos, nextPos);
                Debug.Log("working");
            }
           distOverT = (Time.time - startTime);
            partOfDist = distOverT / 1.7f;
            Debug.Log("working");

            main.transform.position=Vector3.Lerp(startPos, nextPos, partOfDist);
            
        }



    }
    public void setLerpPosition(Vector3 destination)
    {
        nextPos = destination;
        


    }






}
