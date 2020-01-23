using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine_Block : _Block
{
    private void Awake()
    {
        setBlockStats(50, 5, 1,2,0);

    }
    public override void addShipStats()
    {
        Ship_Manager.S.addSpeed((float)blockStats.getValue());
        base.addShipStats();
    }

}
