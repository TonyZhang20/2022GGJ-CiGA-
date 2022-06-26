using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class FullBox : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public BadFood badFood;
    public Sprite fullBoxSprite;
    public UnityEvent afterFoodBad;
    [SerializeField] private float DisableTime;
    [SerializeField] private bool isFreshed;

    private void OnEnable()
    {
        if(DisableTime - GameManager.Instance.worldData.worldTime >= 30f)
        {
            badFood.ResetFood();
            isFreshed = false;
            Debug.Log("Run");
        }
        else
        {
            isFreshed = true;
        }
    }

    private void OnDisable()
    {
        if(!isFreshed)  DisableTime = GameManager.Instance.worldData.worldTime;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (badFood.isClickOnFood)
        {
            badFood.ReleaseEvent.AddListener(ChangeSprite);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        badFood.ReleaseEvent.RemoveAllListeners();
    }

    public void ChangeSprite()
    {
        badFood.ReleaseEvent.RemoveAllListeners();
        badFood.isClickOnFood = false;
        badFood.BaseImage.sprite = fullBoxSprite;
        badFood.gameObject.GetComponent<Image>().raycastTarget = false;

        SimpleDialogue.Instance.StartDialogue("你成功的把过期的食物放到在了食品柜中", 2f);
        Invoke("TurnOffPage",2f);
        isFreshed = false;

        afterFoodBad?.Invoke();
    }

    public void TurnOffPage()
    {
        badFood.BaseImage.gameObject.SetActive(false);
    }



}
