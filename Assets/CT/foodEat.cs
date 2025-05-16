using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class FoodEat : MonoBehaviour
{
    public GameObject food;           // ���� ������Ʈ
    public GameObject customer;       // �� ������Ʈ
    public Image targetImage;         // �� �̹���
    public Sprite customerH1;         // �� �̹��� 1
    public Sprite customerH2;         // �� �̹��� 2
    public Sprite customerH3;         // �� �̹��� 3
    public Sprite customerB2;
    public Sprite customerB3;
    public Image foodImage;
    public Sprite food2;
    public Sprite food3;
    public Sprite food1_ate;
    public Sprite food2_ate;
    public Sprite food3_ate;
    public RectTransform customerT;   // �� RectTransform
    public float animationDuration = 1.5f;  // �ִϸ��̼� ���� �ð�
    private Vector2 startPosition;    // ���� ��ġ
    private Vector2 offscreenPosition; // ȭ�� �� ��ġ
    private Coroutine currentCoroutine;  // ���� ���� ���� �ڷ�ƾ
    public GameObject saybubble;
    public GameObject okButton;
    public Image say;
    public Sprite say1;
    public Sprite say2;
    public Sprite say3;
    void Start()
    {
        // ���İ� �� ��Ȱ��ȭ
        food.SetActive(false);
        customer.SetActive(false);

        // ���� ��ġ�� ȭ�� �Ʒ��� ����
        startPosition = new Vector2(customerT.anchoredPosition.x, Screen.height);
        offscreenPosition = new Vector2(customerT.anchoredPosition.x, -Screen.height);

        // ���� ������ Ȱ��ȭ�Ǵ� ����
        if (randomreciUP.food_ok)
        {
            food.SetActive(true);
            customer.SetActive(true);
        }
        //if (recipeUP.customerNum == 2)
        //    targetImage.sprite = customerB2;
        //if (recipeUP.customerNum == 3)
        //    targetImage.sprite = customerB3;
        if(CookingGameManager.cookingCustomerIndex == 2)
        {
            targetImage.sprite = customerB2;
            foodImage.sprite = food2;
        }
        if(CookingGameManager.cookingCustomerIndex == 3)
        {
            targetImage.sprite = customerB3;
            foodImage.sprite = food3;
        }
            
    }

    public void FoodButton()
    {
        // �̹��� ���� ����
        //if (recipeUP.customerNum == 1)
        //    targetImage.sprite = customerH1;
        //if (recipeUP.customerNum == 2)
        //    targetImage.sprite = customerH2;
        //if (recipeUP.customerNum == 3)
        //    targetImage.sprite = customerH3;
        saybubble.SetActive(true);
        okButton.SetActive(false);
        if (CookingGameManager.cookingCustomerIndex == 1)
        {
            targetImage.sprite = customerH1;
            foodImage.sprite = food1_ate;
            say.sprite = say1;
        }
        if (CookingGameManager.cookingCustomerIndex == 2)
        {
            targetImage.sprite = customerH2;
            foodImage.sprite = food2_ate;
            say.sprite = say2;
        }
        if (CookingGameManager.cookingCustomerIndex == 3)
        {
            targetImage.sprite = customerH3;
            foodImage.sprite = food3_ate;
            say.sprite = say3;
        }

        // �� ������ ��ٸ� �� MoveDown ����
        StartCoroutine(WaitAndMoveDown());
    }

    IEnumerator WaitAndMoveDown()
    {
        yield return new WaitForSeconds(2f); // 1������ ����ؼ� �̹����� ���� �ݿ��ǵ��� ��
        MoveDown();
    }


    // ���� ȭ�� ������ �������� �ϴ� �޼���
    public void MoveDown()
    {
        saybubble.SetActive(false);
        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);

        // ���� ȭ�� ������ �������� �ִϸ��̼�
        currentCoroutine = StartCoroutine(AnimatePanel(offscreenPosition));
    }

    // �ִϸ��̼��� ���� �ڷ�ƾ
    IEnumerator AnimatePanel(Vector2 destination)
    {
        float elapsed = 0f;
        Vector2 initialPosition = customerT.anchoredPosition;

        while (elapsed < animationDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / animationDuration);
            customerT.anchoredPosition = Vector2.Lerp(initialPosition, destination, t);
            yield return null;
        }

        // �ִϸ��̼��� ������ �� ��Ȱ��ȭ (���� ����)
        customer.SetActive(false);
        food.SetActive(false);
        yield return new WaitForSeconds(2f);
        //recipeUP.customerNum++;
        CookingGameManager.cookingCustomerIndex++;
    }
}
