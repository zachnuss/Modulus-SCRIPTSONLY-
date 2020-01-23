using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly_Manager : MonoBehaviour
{
    public Camera cam;
    public Camera_Manager mainCam;

    private void Awake()
    {
        mainCam.main = cam;
        mainCam.setLerpPosition(new Vector3(0, 30, 10));
    }
    public void onFlySceneEnter()
    {
        mainCam.setStartTime = true;
        mainCam.Lerp = true;


    }




}
