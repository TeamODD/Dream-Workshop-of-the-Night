using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;


public class IngredientDroppable : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Image image;

    public CookingControl cookingControl;
    //public CookingCheck cookingCheck;

    //public List<IngredientType> selectedIngredients = new();

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (IngredientDraggable.CurrentDragged != null)
        {
            transform.localScale = new Vector3(1.2f, 1.2f, 1.0f);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = Vector3.one;
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = IngredientDraggable.CurrentDragged;

        if (dropped != null)
        {
            if (transform.name == "Cooking Slot")
            {
                //cookingControl.setFullEmpty(true);
                cookingControl.playFullAnimation();
                dropped.transform.SetParent(transform);
                dropped.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
                Debug.Log("드롭 성공!");
                dropped.SetActive(false);
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

            CanvasGroup group = dropped.GetComponent<CanvasGroup>();
            if (group != null)
            {
                group.blocksRaycasts = true;
                group.alpha = 1.0f;
            }


        }
    }
}
