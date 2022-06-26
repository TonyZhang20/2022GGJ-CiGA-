using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    public Text Score;

    private void Update()
    {
        Score.text = "您的分数是: " + PlayerPrefs.GetFloat("Score").ToString();
    }
}
