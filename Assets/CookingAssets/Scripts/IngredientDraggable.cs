using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class IngredientDraggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Transform canvas;
    private RectTransform draggedRect;
    private GameObject draggedInstance;
    private CanvasGroup originalCanvasGroup;

    public static GameObject CurrentDragged { get; private set; } // ��� ó����

    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>().transform;
        originalCanvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // �ڱ� �ڽ� ����
        draggedInstance = Instantiate(gameObject, canvas); // canvas�� �θ�� ���� (worldPositionStays = false)
        draggedInstance.transform.SetAsLastSibling(); // UI ���� ǥ��

        // RectTransform ����
        RectTransform originalRect = GetComponent<RectTransform>();
        draggedRect = draggedInstance.GetComponent<RectTransform>();

        // ������ ũ��/������ ����
        draggedRect.anchorMin = originalRect.anchorMin;
        draggedRect.anchorMax = originalRect.anchorMax;
        draggedRect.pivot = originalRect.pivot;
        draggedRect.sizeDelta = originalRect.sizeDelta;
        draggedRect.localScale = originalRect.localScale;

        // ���콺 ��ġ�� �̵�
        draggedRect.position = eventData.position;

        // �巡�� ���� ������Ʈ ���� ����
        CurrentDragged = draggedInstance;

        // �������� ĵ���� �׷� ����
        CanvasGroup cloneGroup = draggedInstance.GetComponent<CanvasGroup>();
        if (cloneGroup != null)
        {
            cloneGroup.blocksRaycasts = false;
            cloneGroup.alpha = 0.6f;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (draggedRect != null)
        {
            draggedRect.position = eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (draggedInstance != null)
        {
            // �θ� Canvas �״�θ� ��� ������ �Ŷ� �Ǵ��ؼ� �ı�
            if (draggedInstance.transform.parent == canvas)
            {
                Destroy(draggedInstance);
            }
            else
            {
                // ���������� ��ӵ� ��� ó��
                CanvasGroup cloneGroup = draggedInstance.GetComponent<CanvasGroup>();
                if (cloneGroup != null)
                {
                    cloneGroup.blocksRaycasts = true;
                    cloneGroup.alpha = 1f;
                }
            }
        }

        CurrentDragged = null;
    }
}
