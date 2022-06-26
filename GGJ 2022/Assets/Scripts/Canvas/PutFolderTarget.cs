using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PutFolderTarget : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public MoveComputerFolder moveComputerFolder;

    public void OnPointerEnter(PointerEventData eventData)
    {
        moveComputerFolder.UpMouseEvent.AddListener(DropFolder);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        moveComputerFolder.UpMouseEvent.RemoveAllListeners();
    }

    public void DropFolder()
    {
        moveComputerFolder.folderFollowingMouse.SetActive(false);
        moveComputerFolder.isHidden = true;
        
        moveComputerFolder.AfterSuccessEvent?.Invoke();

        moveComputerFolder.UpMouseEvent.RemoveAllListeners();
    }


}
