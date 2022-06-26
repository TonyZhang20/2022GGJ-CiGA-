using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "PositionData_SO", menuName = "Data/PositionData")]
public class PositionData_SO : ScriptableObject
{
    public List<Transform> WalkAroundPositions;
}

