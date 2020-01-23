using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power_Block : _Block
{
    private void Awake()
    {
        setBlockStats(50, 5, 1,0,0);

    }
    public override void addShipStats()
    {
        Ship_Manager.S.addTotalPower(blockStats.getValue());
        base.addShipStats();
    }
}
