using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//inherted class of all the block types
public class _Block : MonoBehaviour
{
    // struct to hold all the stat info of the block, need to add access functions
    public struct SimpleStats
    {
        int health;
        int value;
        int level;
        int power;
        int creditAmount;
        

        //set stats with values
        public void setStats(int hp,int val,int lvl, int pwr,int cred)
        {
            health = hp;
            //value can be power level, damage or speed armor block currently does not use this value
            value = val;
            level = lvl;
            power = pwr;
            creditAmount = cred;
        }
        //set stats with no values
        public void setStats()
        {
            health = 0;
            value = 0;
            level = 0;
            power = 0;
        }
        //functions to access to values
        public int getHealth()
        {
            return health;

        }
        public int addHealth(int value)
        {
            return health += value;

        }
        public int setHealth(int value)
        {
            return health = value;

        }
        public int getValue()
        {
            return value;

        }
        public int setValue(int num)
        {
            return value+=num;

        }
        public int getLevel()
        {
            return level;

        }
        public int addLevel(int num)
        {
            return level += num;
        }
        public int getCost()
        {
            return creditAmount;
        }
        public int getPowerCost()
        {
            return power;
        }

    }

    
    public SimpleStats blockStats;
    //bool to check if the block itself is connected
    bool isConnected = false;
    //snappoints and snappoints parent object
    public GameObject snap1, snap2, snap3, snap4, snapMaster;



    public void setBlockStats(int hp,int val, int lvl,int pwr,int cred)
    {
        blockStats.setStats(hp, val, lvl, pwr,cred);


    }
    //what the block does when it connects to the ship
    private void onConnect()
    {
        
        //refrence to our parent ship object from our singleton to set the block parent
        transform.parent = Spawn_Button.S.parent.transform;
        addShipStats();
        isConnected = true;
        snapMaster.SetActive(true);
        Spawn_Button.S.failConnect = true;
        addToShipArray();
    }

    //snap too other ship blocks using snappoints
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("working");
        Spawn_Button.S.failConnect = false;
        if (!isConnected&&Input.touchCount>0)
        { 
        if (Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            if (other.gameObject.tag == "SnapPoints")
            {
                    if (checkIf())
                    {
                        transform.position = other.gameObject.transform.position;
                        other.gameObject.SetActive(false);
                        onConnect();
                    }
                    else
                        Destroy(this);
            }
            else if(transform.position.x%1 !=0||transform.position.z%1!=0)
                Destroy(this);



        }
    }

    }
    //kinda jenky way to do this i think? but resets singleton when leaving the snappoints trigger box
    //that way if it dosnt snap it can be deleted at the end of the touch phase
    private void OnTriggerExit(Collider other)
    {
        Spawn_Button.S.failConnect = true;

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "asteroid")
        {
            collision.gameObject.SetActive(false);
            blockStats.addHealth(-10);
            if (blockStats.getHealth() <= 0)
            {
                blockStats.setHealth(50);
                gameObject.SetActive(false);

            }


        }


    }
    public void addToShipArray()
    {
        GameObject newBlock;
        GameObject[] temp;
        int size;
        newBlock = gameObject;

        temp = Ship_Manager.S.blocksInShip;
        size = Ship_Manager.S.blocksInShip.Length;
        Ship_Manager.S.blocksInShip = new GameObject[size + 1];
        for (int i = 0; i < size-1; i++)
        {
            Ship_Manager.S.blocksInShip[i] = temp[i];
        }
        Ship_Manager.S.blocksInShip[size] = newBlock;
        



    }

    //statement checking if total power can support new block
    public bool checkIf()
    {
        return (Ship_Manager.S.spaceCredits >= blockStats.getCost() && Ship_Manager.S.totalPower >= Ship_Manager.S.powerUsed + blockStats.getPowerCost());

    }

    //adds the ship stats to the total ship stats
    public virtual void addShipStats()
    {
        Ship_Manager.S.totalHull += blockStats.getHealth();
        Ship_Manager.S.powerUsed += blockStats.getPowerCost();
        Ship_Manager.S.numBlocks += 1;
    }
}
