using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class IngredientDraggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Transform canvas;
    private RectTransform draggedRect;
    private GameObject draggedInstance;
    private CanvasGroup originalCanvasGroup;

    public static GameObject CurrentDragged { get; private set; } // 드롭 처리용

    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>().transform;
        originalCanvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // 자기 자신 복제
        draggedInstance = Instantiate(gameObject, canvas); // canvas를 부모로 설정 (worldPositionStays = false)
        draggedInstance.transform.SetAsLastSibling(); // UI 위에 표시

        // RectTransform 설정
        RectTransform originalRect = GetComponent<RectTransform>();
        draggedRect = draggedInstance.GetComponent<RectTransform>();

        // 원본의 크기/스케일 복사
        draggedRect.anchorMin = originalRect.anchorMin;
        draggedRect.anchorMax = originalRect.anchorMax;
        draggedRect.pivot = originalRect.pivot;
        draggedRect.sizeDelta = originalRect.sizeDelta;
        draggedRect.localScale = originalRect.localScale;

        // 마우스 위치로 이동
        draggedRect.position = eventData.position;

        // 드래그 중인 오브젝트 전역 참조
        CurrentDragged = draggedInstance;

        // 복제본의 캔버스 그룹 설정
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
            // 부모가 Canvas 그대로면 드롭 실패한 거라 판단해서 파괴
            if (draggedInstance.transform.parent == canvas)
            {
                Destroy(draggedInstance);
            }
            else
            {
                // 성공적으로 드롭된 경우 처리
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
