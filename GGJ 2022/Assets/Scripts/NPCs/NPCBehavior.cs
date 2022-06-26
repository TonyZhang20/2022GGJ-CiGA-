using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCBehavior : MonoBehaviour
{
    //闲逛的点，需要提前输入
    public PositionData_SO positionData;
    public Identity identity;
    public Animator animator;
    public Transform InitialPosition;
    public Transform StopPosition;
    public List<TargetPoint> targetPoint;
    public LocatedPoint locatePoint;
    public NPCData_SO npcData;
    public NavMeshAgent agent;
    public Transform faceDir;
    public bool isWalking;
    public bool isRunning;
    public bool isProgrammer;
    public bool isStandFinish;

    private void Update()
    {
    }

    public void GetInitialPoint(Transform initialPosition)
    {
        InitialPosition = initialPosition;
    }

    #region Animations
    public void WalkAnim()
    {
        animator.SetBool("isWalking", isWalking);
    }

    public void RunAnim()
    {
        animator.SetBool("isRunning", isRunning);
    }

    public void SitAnim()
    {
        animator.SetTrigger("sit");
    }

    public void StandUpAnim()
    {
        animator.SetTrigger("stand");
    }

    public void SadAnim()
    {
        animator.SetTrigger("sad");
    }

    public void OpenDoorAnimation()
    {
        StopMoving();
        animator.SetTrigger("openDoor");
    }

    public void FinishDoor()
    {
        //为了不报错
    }

    public void SetSit()
    {
        animator.SetBool("isProgrammer", isProgrammer);
    }


    #endregion


    public void StopMoving()
    {
        isWalking = false;
        agent.destination = transform.position;
        animator.SetTrigger("stopMoving");
    }

    public void GetIntoWashRoom(float second)
    {
        if (BathRoom.Instance.isFull())
        {
            BathRoom.Instance.waitForBathNpc.Add(gameObject.GetComponent<NPCBehavior>());
            //Stay In Line

        }
    }

    public void Standing()
    {
        isStandFinish = true;
    }

    /// <summary>
    /// 离开座位进行漫无目的的瞎逛
    /// </summary>
    public void Stretch(Vector3 walkAroundPosition)
    {
        locatePoint.behaviour = mBehaviour.Standing;
        agent.destination = walkAroundPosition;

        StandUpAnim();
        StartCoroutine(WalkAround(walkAroundPosition));
    }

    IEnumerator WalkAround(Vector3 walkAroundPosition)
    {
        yield return new WaitUntil(() => isStandFinish == true);
        isStandFinish = false;

        isWalking = true;

        WalkAnim();

        agent.destination = walkAroundPosition;

        yield return new WaitUntil(() => agent.hasPath == false);

        StartCoroutine(StaySomewhereForSecond(2f));
    }

    IEnumerator StaySomewhereForSecond(float time)
    {
        StopMoving();

        yield return new WaitForSeconds(time);

        StartCoroutine(BackToSeat());
    }

    public void GoBackToWork()
    {
        StartCoroutine(BackToSeat());
    }

    IEnumerator BackToSeat()
    {
        yield return new WaitForSeconds(1);

        isWalking = true;
        WalkAnim();

        agent.destination = InitialPosition.position;
        //Debug.Log(faceDir);

        yield return new WaitForSeconds(0.5f);

        transform.LookAt(faceDir);

        yield return new WaitUntil(() => agent.hasPath == false);

        locatePoint.behaviour = mBehaviour.Working;

        if (agent.hasPath == false)
        {
            isWalking = false;
            WalkAnim();

            SitAnim();
        }
    }
}

public enum Identity
{
    Programmer,
    Engineer,
    Security,
    Contestants
}

public enum mBehaviour
{
    Bath,
    Eat,
    Working,
    Standing
}

[System.Serializable]
public class TargetPoint
{
    public mBehaviour behaviour;
    public Transform TargetPosition;
}

[System.Serializable]
public class LocatedPoint
{
    public mBehaviour behaviour;
    public Transform StartPosition;
}