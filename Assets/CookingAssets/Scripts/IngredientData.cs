using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientData : MonoBehaviour
{
    public enum IngredientType { Milk, Butter, Egg, Special1, Special2, Special3 }

    public IngredientType ingredientType;

    [Header("UI�� �̹��� ������Ʈ")]
    public Image image;

    [Header("��������Ʈ �迭 (���� �߿�)")]
    public Sprite[] sprites;

    // �ܺο��� Ÿ�� ���� �� ȣ��
    public void SetType(IngredientType newType)
    {
        ingredientType = newType;
        image.sprite = sprites[(int)ingredientType];
    }

}
