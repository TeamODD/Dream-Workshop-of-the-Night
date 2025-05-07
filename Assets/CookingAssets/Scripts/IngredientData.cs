using UnityEngine;
using UnityEngine.UI;

public class IngredientData : MonoBehaviour
{
    public enum IngredientType { Sugar, Butter, Egg }

    public IngredientType type;

    [Header("UI용 이미지 컴포넌트")]
    public Image image;

    [Header("스프라이트 배열 (순서 중요)")]
    public Sprite[] sprites;

    // 외부에서 타입 지정 시 호출
    public void SetType(IngredientType newType)
    {
        type = newType;
        image.sprite = sprites[(int)type];
    }
}
