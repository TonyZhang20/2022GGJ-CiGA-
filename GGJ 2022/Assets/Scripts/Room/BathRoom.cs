using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathRoom : SingleTon<BathRoom>
{
    public Transform bathRoom;
    public int maxPeople;
    public int people;
    public bool isBranded;
    public List<NPCBehavior> waitForBathNpc;

    public bool isFull()
    {
        return people == maxPeople || isBranded;
    }

    private void Update()
    {

    }


}
