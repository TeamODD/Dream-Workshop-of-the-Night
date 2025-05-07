using UnityEngine;
using UnityEngine.UI;

public class IngredientData : MonoBehaviour
{
    public enum IngredientType { Sugar, Butter, Egg }

    public IngredientType type;

    [Header("UI�� �̹��� ������Ʈ")]
    public Image image;

    [Header("��������Ʈ �迭 (���� �߿�)")]
    public Sprite[] sprites;

    // �ܺο��� Ÿ�� ���� �� ȣ��
    public void SetType(IngredientType newType)
    {
        type = newType;
        image.sprite = sprites[(int)type];
    }
}
