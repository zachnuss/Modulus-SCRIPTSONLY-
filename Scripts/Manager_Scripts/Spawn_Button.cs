using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//NEED TO CHANGE SCRIPT NAME INCORECT
// more of a game manager script for the build scene
//manages all build controls
public class Spawn_Button : MonoBehaviour
{
    //for checking of block is spawned already
    public bool blockSpawned = false;
    //to test after touch end if te block is connected
    public bool failConnect = true;
    //all the block types
    public GameObject weaponBlock, powerBlock,engineBlock,armorBlock;
    //refrence to the buttonpanel and the parent ship object
    public GameObject parent, panel;
    //refrence to the newly created block so easily deletable if needed
    private GameObject newBlock;

    //singleton creation, need to look in to scriptabe objects
    public static Spawn_Button S;


    private void Awake()
    {
        S = this;

    }
   
    // update function pretty much just for block touch and drag controls
    private void Update()
    {
        //touch and drag for blocks
        if(Input.touchCount>0&&blockSpawned == true)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                
                Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 20));
                
                newBlock.transform.position = Vector3.Lerp(newBlock.transform.position, touchedPos, Time.deltaTime * 8);
            }
            if(touch.phase == TouchPhase.Ended)
            {
                blockSpawned = false;
                if (failConnect)
                {
                    Destroy(newBlock);
                }
                
            }

        }

    }
    //spawns block, used in those four functions down there
    private void spawnBlock(GameObject block)
    {

        if (!blockSpawned)
        {
            Touch touch = Input.GetTouch(0);
            Debug.Log(touch.position);
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 20));
            newBlock = Instantiate(block, worldPos, Quaternion.identity);
            Debug.Log(worldPos);
            blockSpawned = true;
        }

    }
    //these four functions all do the same thing, i think theres a better way to do this but fuck if i know
    public void spawnWeaponBlock()
    {
        spawnBlock(weaponBlock);
    }
    public void spawnPowerBlock()
    {
        spawnBlock(powerBlock);
    }
    public void spawnArmorBlock()
    {
        spawnBlock(armorBlock);
    }
    public void spawnEngineBlock()
    {
        spawnBlock(engineBlock);
    }








}


