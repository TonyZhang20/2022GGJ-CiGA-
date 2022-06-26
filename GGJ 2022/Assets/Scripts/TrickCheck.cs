using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrickCheck : MonoBehaviour
{
    [SerializeField] private GameObject computerOption;
    [SerializeField] private GameObject foodOption;
    [SerializeField] private GameObject videoOption;
    [SerializeField] private GameObject itemOption;
    [SerializeField] private GameObject Player;

    private void Update()
    {

        // if (Input.GetKeyDown(KeyCode.E))
        // {
        //     RayCastCheck();
        // }
    }

    private void RayCastCheck()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Player.transform.forward, out hit, 0.5f))
        {
            Debug.Log("Hit");
            if (hit.transform.gameObject.CompareTag("Computer"))
            {
                ComputerOption();
            }
        }
    }
    private void ComputerOption()
    {
        Debug.Log("Run");
        computerOption.SetActive(true);
    }
}
