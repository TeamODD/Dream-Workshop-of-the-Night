using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

public class IngredientDroppable : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Image image;
    
    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = Color.yellow;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = Color.white;
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = IngredientDraggable.CurrentDragged;

        if (dropped != null)
        {
            if (transform.name == "Cooking Slot")
            {
                dropped.transform.SetParent(transform);
                dropped.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
                Debug.Log("드롭 성공!");
                //GameManager.Instance.cookingCheck;
            }
            else if (transform.name == "Output")
            {
                Debug.Log("손님에게 줬다");
            }
            else if (transform.name == "Trash Can")
            {
                Debug.Log("쓰레기통으로 슛");
                Destroy(dropped);
            }

            CanvasGroup group = dropped.GetComponent<CanvasGroup>();
            if (group != null)
            {
                group.blocksRaycasts = true;
                group.alpha = 1.0f;
            }

            
        }
    }
}
