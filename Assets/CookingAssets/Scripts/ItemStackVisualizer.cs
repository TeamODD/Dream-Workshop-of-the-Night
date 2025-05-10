using UnityEngine;
using UnityEngine.UI;

public class ItemStackVisualizer : MonoBehaviour
{
    [Header("�ʿ��� ���۷���")]
    public GameObject itemImagePrefab; // ������ �̹��� ������
    public Transform container;        // �̹������� �� �θ�

    [Header("����")]
    public int maxVisualCount = 5;     // ȭ�鿡 ������ �ִ� ����
    public Vector2 offsetPerImage = new Vector2(-5f, -5f); // ��ġ�� ������

    public void ShowItemCount(int count)
    {
        // ���� �̹��� ����
        foreach (Transform child in container)
        {
            Destroy(child.gameObject);
        }

        // �ִ� �ð� ���� ����
        int visualCount = Mathf.Min(count, maxVisualCount);

        for (int i = 0; i < visualCount; i++)
        {
            GameObject clone = Instantiate(itemImagePrefab, container);
            RectTransform rt = clone.GetComponent<RectTransform>();

            // �������� ��ġ (��¦ ��߳�)
            rt.anchoredPosition = i * offsetPerImage;
            rt.SetAsFirstSibling(); // ���߿� ������ �� ������ ������
        }
    }
}