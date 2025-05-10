using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSize : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Vector3 upsize = new Vector3(1.2f, 1.2f, 1f);
    private Vector3 normalsize;

    void Start()
    {
        normalsize = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = upsize;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = normalsize;
    }
}
