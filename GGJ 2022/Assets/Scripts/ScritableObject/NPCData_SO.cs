using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NPCData_SO", menuName = "Data/NPCData")]
public class NPCData_SO : ScriptableObject
{
    public float happiness;
    public float washRoomRate;
    public float speed;
    public bool report;
    public bool isHot;

}

