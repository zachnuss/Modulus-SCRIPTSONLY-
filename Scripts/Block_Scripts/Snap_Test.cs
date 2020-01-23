using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// on every snap point object to test if a valid test point
public class Snap_Test : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (!Spawn_Button.S.blockSpawned)
        {
            // turns of comes in cotact with a newly connected block
            if(other.tag == "Block")
            {
                gameObject.SetActive(false);
            }
            //if another snappoint object found deletes the one that is the lower number
            if(other.tag == "SnapPoints")
            {
                int otherNum, thisNum;

                otherNum = int.Parse(other.name[5].ToString());
                thisNum = int.Parse(gameObject.name[5].ToString());
                if (thisNum < otherNum)
                {
                    gameObject.SetActive(false);

                }
            }

        }


    }
}
