using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class customerUP : MonoBehaviour
{
    public RectTransform customer;
    public float animationDuration = 0.5f;
    public Vector2 targetPosition;
    private Vector2 startPosition;
    private Coroutine currentCoroutine;
    public GameObject saybubble;
    public GameObject okButton;
    public Image customerImage;
    public Sprite customer2;
    public Sprite customer3;
    static bool is_1 = false, is_2 = false, is_3 = false;
    public Image say;
    public Sprite say2;
    public Sprite say3;
    void Start()
    {
        startPosition = new Vector2(targetPosition.x, -Screen.height);
        customer.anchoredPosition = startPosition;
        saybubble.SetActive(false);
    }
    private void Update()
    {
        //int customerNum = recipeUP.customerNum;
        int customerNum = CookingGameManager.cookingCustomerIndex;
        if (customerNum == 1&&!is_1)
        {
            is_1 = true;
            MoveUp();
        }
        if(customerNum == 2&&!is_2)
        {
            customerImage.sprite = customer2;
            is_2= true;
            MoveUp();
        }
        if (customerNum == 3 && !is_3)
        {
            customerImage.sprite = customer3;
            is_3 = true;
            MoveUp();
        }
    }
    public void MoveUp()
    {
        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);
        currentCoroutine = StartCoroutine(AnimatePanel(targetPosition));
    }
    public void MoveDown()
    {
        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);
        currentCoroutine = StartCoroutine(AnimatePanel(startPosition));
    }
    IEnumerator AnimatePanel(Vector2 destination)
    {
        float elapsed = 0f;
        Vector2 initialPosition = customer.anchoredPosition;

        while (elapsed < animationDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / animationDuration);
            customer.anchoredPosition = Vector2.Lerp(initialPosition, destination, t);
            yield return null;
        }

        customer.anchoredPosition = destination;
        if (destination == targetPosition)
        {
            saybubble.SetActive(true);
            okButton.SetActive(true);
            int customerNum = CookingGameManager.cookingCustomerIndex;
            if (customerNum == 2)
            {
                say.sprite = say2;
            }
            else if (customerNum == 3)
            {
                say.sprite= say3;
            }
        }
    }
}