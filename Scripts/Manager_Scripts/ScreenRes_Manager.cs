using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//manages screen res only called at begining of game
public class ScreenRes_Manager : MonoBehaviour
{
    int height, width;



    private void Awake()
    {
        
    }

    private void getScreenRes()
    {
        height = Screen.height;
        width = Screen.width;
        Screen.SetResolution(width,height,true);

    }
}
