using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class ChangeCompleteFood : MonoBehaviour
{
    public List<Sprite> completeFoodSprites;

    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void setSprite()
    {
        image.sprite = completeFoodSprites[CookingGameManager.cookingCustomerIndex];
    }
}
