using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : SingleTon<ChangeScene>
{
    public void GoToStartScene()
    {
        SceneManager.LoadScene(0);
    }
    public void GoToGameScene()
    {
        SceneManager.LoadScene(1);
    }
    public void GoToEndScene()
    {
        SceneManager.LoadScene(2);
    }

    public void GoToScoreScene()
    {
        SceneManager.LoadScene(3);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
