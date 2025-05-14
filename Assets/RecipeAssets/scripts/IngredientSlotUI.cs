using UnityEngine;
using UnityEngine.UI;  // Image, Text 사용 시 필수
using System;

[System.Serializable]
public class IngredientSlotUI
{
    public Image icon;
    public Text countText;

    public void SetIngredient(string ingredientName, int count)
    {
        Sprite sprite = Resources.Load<Sprite>($"Sprites/{ingredientName}");
        if (sprite != null)
        {
            icon.sprite = sprite;
            icon.gameObject.SetActive(true);
            countText.text = $"x{count}";
        }
        else
        {
            icon.gameObject.SetActive(false);
            countText.text = "";
            Debug.LogWarning($"Sprite not found: {ingredientName}");
        }
    }

    public void Clear()
    {
        icon.gameObject.SetActive(false);
        countText.text = "";
    }
}
