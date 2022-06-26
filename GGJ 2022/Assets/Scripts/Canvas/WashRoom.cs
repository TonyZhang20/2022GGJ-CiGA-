using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
public class WashRoom : MonoBehaviour, IPointerClickHandler
{
    public Image BasicImage;
    public Sprite WashRoomWithNothing;
    public Sprite WashRoomWithWarning;
    public bool isBrand;
    public UnityEvent AfterEvent;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (GameManager.Instance.hasBrand && !isBrand)
        {
            isBrand = true;
            BasicImage.sprite = WashRoomWithWarning;
            SimpleDialogue.Instance.StartDialogue("你把“正在打扫”的牌子放在了厕所门口，这下子参赛选手们要急坏了",3f);
            GameManager.Instance.hasBrand = false;
            AfterEvent?.Invoke();
        }
    }

    private void Update()
    {
        if (isBrand)
        {
            Invoke("TurnOffPage", 3f);
        }
    }

    public void TurnOffPage()
    {
        BasicImage.gameObject.SetActive(false);
    }

    public void Reset()
    {
        BasicImage.sprite = WashRoomWithNothing;
        isBrand = false;
    }
}
