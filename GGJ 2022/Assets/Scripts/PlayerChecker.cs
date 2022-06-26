using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using HighlightingSystem;
public class PlayerChecker : MonoBehaviour
{
    [SerializeField] private Highlighter highlighter;
    public UnityEvent OnPressEvent;
    public NPCBehavior myNpc;
    private bool hasNpc;
    public bool hasPlayer;

    public void SetHasPlayer()
    {
        hasPlayer = false;
    }

    private void Update()
    {
        if(hasPlayer && Input.GetKeyDown(KeyCode.E))
        {
            //添加一个检查事件
            if(GameManager.Instance.hasSer)
            {
                SimpleDialogue.Instance.StartDialogue("保安在边上，还是不要做小动作的好", 1.5f);
            }
            else if(myNpc == null || myNpc.locatePoint.behaviour != mBehaviour.Working)
            {
                OnPressEvent?.Invoke();
            }
            else
            {
                SimpleDialogue.Instance.StartDialogue("这位小伙伴正在很认真的创作,打扰他一定会被发现的!",3f);
            }

            //Debug.Log("Run");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hasPlayer = true;
            highlighter.TweenStart();
            highlighter.tweenDuration = 1f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hasPlayer = false;
            highlighter.TweenStop();
        }
    }

}
