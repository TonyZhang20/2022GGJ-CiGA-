using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    public int tableID;
    public List<Contester> contester;
    public List<Transform> agentTarget;
    

    private void Start()
    {
        //给所有NPC赋值工作岗位坐标
        foreach (var team in contester)
        {
            team.contestants.GetComponent<NPCBehavior>().GetInitialPoint(team.Seat);
            team.contestants.GetComponent<NPCBehavior>().faceDir = team.deskTop.transform;
            team.contestants.GetComponent<NPCBehavior>().GoBackToWork();
            team.deskTop.GetComponentInChildren<PlayerChecker>().myNpc = team.contestants.GetComponent<NPCBehavior>();
        }
    }

    private void Update()
    {
        float num = Random.Range(0f,100f);
        if(num <= 0.2 && isEveryoneWorking())
        {
            int index = Random.Range(0, contester.Count);
            int target = Random.Range(0, agentTarget.Count);

            contester[index].contestants.GetComponent<NPCBehavior>().Stretch(agentTarget[target].position);
        }
    }

    bool isEveryoneWorking()
    {
        foreach (var team in contester)
        {
            if(team.contestants.GetComponent<NPCBehavior>().locatePoint.behaviour != mBehaviour.Working)
            {
                return false;
            }
        }
        return true;
    }

}
[System.Serializable]
public class Contester
{
    public GameObject contestants;
    public GameObject deskTop;
    public Transform Seat;
}
