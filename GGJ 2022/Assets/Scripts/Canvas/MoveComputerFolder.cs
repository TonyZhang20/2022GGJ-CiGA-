using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MoveComputerFolder : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public UnityEvent AfterSuccessEvent;
    public UnityEvent UpMouseEvent;
    public GameObject folder;
    public GameObject folderFollowingMouse;
    public bool isClickOnFolder;
    public bool isHidden;

    private void OnEnable()
    {
        Reset();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isHidden) return;

        isClickOnFolder = true;
        folder.SetActive(false);
        folderFollowingMouse.SetActive(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        UpMouseEvent?.Invoke();

        if (!isHidden)
        {
            Reset();
        }
        else
        {
            SimpleDialogue.Instance.StartDialogue("你把文件夹藏了起来.",3f);
            StartCoroutine(Talking());
        }
    }

    private void Update()
    {
        if (isClickOnFolder)
        {
            folderFollowingMouse.GetComponent<RectTransform>().position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        }
    }

    public void Reset()
    {
        isHidden = false;
        folder.SetActive(true);
        folderFollowingMouse.SetActive(false);
    }

    IEnumerator Talking()
    {
        //显示字幕表示完成隐藏 -- 已完成
        yield return new WaitForSeconds(3f);
        transform.parent.gameObject.SetActive(false);
    }


}
