using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private Animator animator;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private PlayerData_SO playerData;
    private bool canMove = false;
    public bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        canMove = false;
        Invoke("EnableMoving", 0.5f);
        GameManager.Instance.RegisterPlayer(playerData);
    }

    void EnableMoving()
    {
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove) MoveMent();
        if(Input.GetKeyDown(KeyCode.E) && isOpen)
        {
            OpenDoor();
        }
    }
    private void MoveMent()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        characterController.SimpleMove(move * Time.deltaTime * speed * 10f);

        if (move != Vector3.zero)
        {
            transform.forward = move;
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }
    public void OpenDoor()
    {
        canMove = false;
        animator.SetLayerWeight(1, 1);
    }

    public void FinishDoor()
    {
        canMove = true;
        animator.SetLayerWeight(1, 0);
    }

}
