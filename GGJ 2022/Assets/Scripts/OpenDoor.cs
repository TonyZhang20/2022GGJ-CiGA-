using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{

    [SerializeField] private Animator animator;
    private bool isOpen;

    public void Open()
    {
        if(!isOpen)
        {
            animator.SetTrigger("Open");
            isOpen = true;
        } 
    }

    public void Close()
    {
        if(isOpen)
        {
            animator.SetTrigger("Close");
            isOpen = false;
        }
    }


}
