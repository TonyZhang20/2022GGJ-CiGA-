using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WorldData_SO", menuName = "Data/WorldData")]
public class WorldData_SO : ScriptableObject
{
    [Header("World Data")]
    public float patience;
    public float warning;
    public float worldTime;

    [Header("Player Data")]
    public float score;


}
