using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Manager : MonoBehaviour
{
    public bool moveLeft= false, moveRight= false;

    float speed = 3;
    public int totalPower;
    public int powerUsed;
    public int totalHull;
    public int spaceCredits;
    public int spaceDiamonds;
    public int numBlocks;
    public static Ship_Manager S;
    public GameObject[] blocksInShip;

    private void Awake()
    {
        totalPower = 5;
        S = this;
    }


    private void Update()
    {
        if (moveLeft&&transform.position.x<10)
        {
            moveL();

        }
        if (moveRight&&transform.position.x>-10)
        {
            moveR();
        }
    }


    //all the move functions, they are backwards but idc tbh right i left and left is right
    private void moveL()
    {
        Vector3 temp = transform.position;
        temp.x += Time.deltaTime * speed;
        transform.position = temp;


    }
    private void moveR()
    {
        Vector3 temp = transform.position;
        temp.x -= Time.deltaTime * speed;
        transform.position = temp;
    }
    //functions to set bools for moving
    public void moveToLeft()
    {
        moveLeft = true;
    }
    public void moveToRight()
    {
        moveRight= true;
    }
    public void endToLeft()
    {
        moveLeft = false;
    }
    public void endToRight()
    {
        moveRight = false;
    }
    //adding stats to the ship
    public void addTotalPower(int value)
    {
        totalPower += value;


    }
    public void addSpeed(float value)
    {
        speed += value;
    }
    public void addTotalHull(int value)
    {
        totalHull += value;

    }
    public void addPowerUsed(int value)
    {

        powerUsed += value;

    }
    public bool checkTotlPower(int value)
    {
         return totalPower >= (powerUsed + value);
    }

}
