using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addWarning : MonoBehaviour
{
    public void Add10()
    {
        GameManager.Instance.worldData.warning += 10;
        GameManager.Instance.worldData.score += 50;
    }

    public void Add20()
    {
        GameManager.Instance.worldData.warning += 20;
        GameManager.Instance.worldData.score += 200;
    }

    public void add30()
    {
        GameManager.Instance.worldData.warning += 30;
        GameManager.Instance.worldData.score += 800;
    }
}
