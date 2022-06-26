using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDescr : MonoBehaviour
{

    // Start is called before the first frame update
    private void OnEnable()
    {
        Invoke("ChangeAfterSecond",8f);
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ChangeAfterSecond();
        }
    }

    private void ChangeAfterSecond()
    {
        ChangeScene.Instance.GoToGameScene();
    }
    
}
