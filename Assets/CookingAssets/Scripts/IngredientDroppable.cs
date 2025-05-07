using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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
            dropped.transform.SetParent(transform);
            dropped.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;

            var group = dropped.GetComponent<CanvasGroup>();
            if (group != null)
            {
                group.blocksRaycasts = true;
                group.alpha = 1.0f;
            }

            Debug.Log("드롭 성공!");
        }
    }
}
