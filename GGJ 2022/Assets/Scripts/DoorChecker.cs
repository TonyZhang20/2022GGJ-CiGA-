using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using HighlightingSystem;
public class DoorChecker : MonoBehaviour
{

    [SerializeField] private Highlighter highlighter;
    public UnityEvent OnPressEvent;
    public UnityEvent LeaveEvent;
    private bool hasNpc;
    private bool hasPlayer;

    private void Update()
    {
        if(hasPlayer && Input.GetKeyDown(KeyCode.E))
        {
            OnPressEvent?.Invoke();
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
            LeaveEvent?.Invoke();
        }
    }


}
