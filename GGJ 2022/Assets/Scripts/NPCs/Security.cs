using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Security : MonoBehaviour
{
    public Animator animator;
    public NavMeshAgent agent;
    public List<Transform> targetPosition;



    private void Update()
    {
        if(!agent.hasPath)
        {
            int target = Random.Range(0,targetPosition.Count);
            agent.speed = 6;
            agent.destination = targetPosition[target].position;
            animator.SetBool("isRunning",true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.hasSer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.hasSer = false;
        }
    }

}
