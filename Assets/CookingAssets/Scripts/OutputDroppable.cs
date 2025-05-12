using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OutputDroppable : MonoBehaviour, IPointerEnterHandler, IDropHandler, IPointerExitHandler
{
    private Image image;
    private RectTransform rect;

    private void Awake()
    {
        image = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = Color.yellow;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = Color.white;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            GameObject dragged = eventData.pointerDrag;
            if(transform.name == "Output")
            {
                dragged.transform.SetParent(null);
                DontDestroyOnLoad(dragged);
                SceneManager.LoadScene("CustomerScene");
            }
            else if (transform.name == "Trash Can")
            {
                Debug.Log("쓰레기통으로 슛");
                Destroy(dragged);
            }
        }
    }
}
