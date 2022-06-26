using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashRoomReset : MonoBehaviour
{
    public GameObject board;
    public GameObject stack;
    public WashRoom washRoom;
    [SerializeField] private float waitTime;
    [SerializeField] private float localTime;
    private bool isReset;

    private void OnEnable()
    {
        waitTime = 25f;
        isReset = false;
    }

    private void Update()
    {
        if(!isReset)
        {
            localTime += Time.deltaTime;
            if(localTime >= 1)
            {
                waitTime -= 1;
                localTime = 0;
            }

            if(waitTime == 0)
            {
                Reset();
            }
        }
    }

    private void Reset()
    {
        isReset = true;
        washRoom.Reset();
        board.SetActive(false);
        stack.SetActive(true);
        gameObject.SetActive(false);
    }

}
