using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerOption : MonoBehaviour
{
    public GameObject Computer;
    public void OptionOne()
    {
        Computer.SetActive(false);
    }

    public void OptionTwo()
    {
        Computer.SetActive(false);
    }

    public void OptionThree()
    {
        FindObjectOfType<ChildList>().Children[2].SetActive(true);
        Computer.SetActive(false);
    }

    public void OptionFour()
    {
        Computer.SetActive(false);
    }
}
