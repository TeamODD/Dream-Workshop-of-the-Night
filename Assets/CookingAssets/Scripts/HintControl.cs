using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HintControl : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject hintPanel;
    public Button hintButton;
    private RectTransform rect;

    private void Awake()
    {
        hintButton.interactable = true;
        rect = GetComponent<RectTransform>();
    }

    public void OnClick()
    {
        hintButton.interactable = false;
        hintPanel.SetActive(true);
        hintButton.transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        StartCoroutine(openHint());
    }

    private IEnumerator openHint()
    {
        yield return new WaitForSeconds(5.0f);
        hintPanel.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        rect.localScale = new Vector3(1.2f, 1.2f, 1.0f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        rect.localScale = Vector3.one;
    }
}
