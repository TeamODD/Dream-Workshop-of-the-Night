using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class FoodEat : MonoBehaviour
{
    public GameObject food;           // 음식 오브젝트
    public GameObject customer;       // 고객 오브젝트
    public Image targetImage;         // 고객 이미지
    public Sprite customerH1;         // 고객 이미지 1
    public Sprite customerH2;         // 고객 이미지 2
    public Sprite customerH3;         // 고객 이미지 3
    public Sprite customerB2;
    public Sprite customerB3;
    public RectTransform customerT;   // 고객 RectTransform
    public float animationDuration = 1.5f;  // 애니메이션 지속 시간
    private Vector2 startPosition;    // 시작 위치
    private Vector2 offscreenPosition; // 화면 밖 위치
    private Coroutine currentCoroutine;  // 현재 실행 중인 코루틴

    void Start()
    {
        // 음식과 고객 비활성화
        food.SetActive(false);
        customer.SetActive(false);

        // 시작 위치를 화면 아래로 설정
        startPosition = new Vector2(customerT.anchoredPosition.x, Screen.height);
        offscreenPosition = new Vector2(customerT.anchoredPosition.x, -Screen.height);

        // 고객과 음식이 활성화되는 조건
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
            targetImage.sprite = customerB2;
        if(CookingGameManager.cookingCustomerIndex == 3)
            targetImage.sprite = customerB3;
    }

    public void FoodButton()
    {
        // 이미지 먼저 변경
        //if (recipeUP.customerNum == 1)
        //    targetImage.sprite = customerH1;
        //if (recipeUP.customerNum == 2)
        //    targetImage.sprite = customerH2;
        //if (recipeUP.customerNum == 3)
        //    targetImage.sprite = customerH3;
        if(CookingGameManager.cookingCustomerIndex == 1)
            targetImage.sprite = customerH1;
        if (CookingGameManager.cookingCustomerIndex == 2)
            targetImage.sprite = customerH2;
        if (CookingGameManager.cookingCustomerIndex == 3)
            targetImage.sprite = customerH3;

        // 한 프레임 기다린 뒤 MoveDown 실행
        StartCoroutine(WaitAndMoveDown());
    }

    IEnumerator WaitAndMoveDown()
    {
        yield return new WaitForSeconds(2f); // 1프레임 대기해서 이미지가 먼저 반영되도록 함
        MoveDown();
    }


    // 고객을 화면 밖으로 내려가게 하는 메서드
    public void MoveDown()
    {
        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);

        // 고객이 화면 밖으로 내려가는 애니메이션
        currentCoroutine = StartCoroutine(AnimatePanel(offscreenPosition));
    }

    // 애니메이션을 위한 코루틴
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

        // 애니메이션이 끝나면 고객 비활성화 (선택 사항)
        customer.SetActive(false);
        food.SetActive(false);
        yield return new WaitForSeconds(2f);
        //recipeUP.customerNum++;
        CookingGameManager.cookingCustomerIndex++;
    }
}
