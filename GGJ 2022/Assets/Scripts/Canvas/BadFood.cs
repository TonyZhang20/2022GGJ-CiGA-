using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BadFood : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Image BaseImage;
    public Sprite BasicSprite;
    public Sprite EmptySprite;
    public GameObject Food;
    public bool isClickOnFood;
    public UnityEvent ReleaseEvent;

    public void OnPointerDown(PointerEventData eventData)
    {
        isClickOnFood = true;

        BaseImage.sprite = EmptySprite;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Debug.Log("Mouse uP");

        BaseImage.sprite = BasicSprite;

        ReleaseEvent?.Invoke();

        isClickOnFood = false;
        Food.SetActive(false);
    }

    public void ResetFood()
    {
        gameObject.GetComponent<Image>().raycastTarget = true;
        BaseImage.sprite = BasicSprite;
    }

    void Update()
    {
        if (isClickOnFood)
        {
            Food.SetActive(true);
            Food.GetComponent<RectTransform>().position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        }
    }
}
