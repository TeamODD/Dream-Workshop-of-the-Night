using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;
using static IngredientData;

public class IngredientDroppable : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Image image;
    //public CookingCheck cookingCheck;

    //public List<IngredientType> selectedIngredients = new();

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
                IngredientData ingredientData = dropped.GetComponent<IngredientData>();
                if (ingredientData != null)
                {
                    Debug.Log(ingredientData.ingredientType);
                    CookingCheck.inputIngredientList.Add(ingredientData.ingredientType);
                    //cookingCheck.inputIngredientList.Add(ingredientData.ingredientType);
                    //selectedIngredients.Add(ingredientData.ingredientType);
                    //cookingCheck.setInputIngredientList(ingredientData.ingredientType);
                }
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
