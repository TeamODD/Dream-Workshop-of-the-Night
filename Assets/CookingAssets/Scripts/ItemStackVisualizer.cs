using UnityEngine;
using UnityEngine.UI;

public class ItemStackVisualizer : MonoBehaviour
{
    [Header("필요한 레퍼런스")]
    public GameObject itemImagePrefab; // 복제할 이미지 프리팹
    public Transform container;        // 이미지들이 들어갈 부모

    [Header("설정")]
    public int maxVisualCount = 5;     // 화면에 보여질 최대 수량
    public Vector2 offsetPerImage = new Vector2(-5f, -5f); // 겹치는 오프셋

    public void ShowItemCount(int count)
    {
        // 기존 이미지 제거
        foreach (Transform child in container)
        {
            Destroy(child.gameObject);
        }

        // 최대 시각 수량 제한
        int visualCount = Mathf.Min(count, maxVisualCount);

        for (int i = 0; i < visualCount; i++)
        {
            GameObject clone = Instantiate(itemImagePrefab, container);
            RectTransform rt = clone.GetComponent<RectTransform>();

            // 겹쳐지게 배치 (살짝 어긋남)
            rt.anchoredPosition = i * offsetPerImage;
            rt.SetAsFirstSibling(); // 나중에 생성된 게 밑으로 가도록
        }
    }
}