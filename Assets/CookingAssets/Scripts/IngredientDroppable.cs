using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;


public class IngredientDroppable : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Image image;

    public CookingControl cookingControl;
    public CustomerDataControl customerDataControl;

    private List<string> ingredientName = new List<string>();

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
                cookingControl.playFullAnimation();
                dropped.transform.SetParent(transform);
                dropped.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
                Debug.Log("드롭 성공!");
                dropped.SetActive(false);
                inputIngredient(dropped.name);
            }

            CanvasGroup group = dropped.GetComponent<CanvasGroup>();
            if (group != null)
            {
                group.blocksRaycasts = true;
                group.alpha = 1.0f;
            }


        }
    }

    private void inputIngredient(string name)
    {
        if (name == "SugarOne(Clone)")
        {
            ingredientName.Add("Sugar");
        }
        else if (name == "ButterOne(Clone)")
        {
            ingredientName.Add("Butter");
        }
        else if (name == "EggOne(Clone)")
        {
            ingredientName.Add("Egg");
        }
        else if (name == "Special1One(Clone)")
        {
            ingredientName.Add("Special1");
        }
        else if (name == "Special2One(Clone)")
        {
            ingredientName.Add("Special2");
        }
        else if (name == "Special3One(Clone)")
        {
            ingredientName.Add("Special3");
        }
    }

    public List<string> getIngredientName()
    {
        return ingredientName;
    }

    public void setIngredientClear()
    {
        ingredientName.Clear();
    }
}
