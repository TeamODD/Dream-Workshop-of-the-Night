using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OutputDroppable : MonoBehaviour, IPointerEnterHandler, IDropHandler, IPointerExitHandler
{
    private Image image;
    private RectTransform rect;
    public CookingControl cookingControl;
    public CustomerDataControl customerDataControl;

    private void Awake()
    {
        image = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            transform.localScale = new Vector3(1.2f, 1.2f, 1.0f);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            transform.localScale = Vector3.one;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            GameObject dragged = eventData.pointerDrag;
            if(transform.name == "Output" && eventData.pointerDrag.name != "Cooking Slot")
            {
                dragged.transform.SetParent(null);
                //CookingGameManager.Instance.setCookingSceneIndex();
                customerDataControl.changeCustomerSprite();
                CookingGameManager.cookingSceneCustomerIndex++;
                Destroy(dragged);
                if(CookingGameManager.cookingSceneChange == 1)
                {
                SceneManager.LoadScene("CTEasy");
                }
                else if(CookingGameManager.cookingSceneChange == 2)
                {
                    SceneManager.LoadScene("CTNoraml");
                }
                else if(CookingGameManager.cookingSceneChange == 3)
                {
                    SceneManager.LoadScene("CTHard");
                }
            }
            else if (transform.name == "Trash Can")
            {
                Debug.Log("쓰레기통으로 슛");
                cookingControl.playEmptyAnimation();
            }
        }
    }
}
