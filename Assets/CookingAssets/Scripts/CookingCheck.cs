using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 
/// </summary>
public class CookingCheck : MonoBehaviour
{
    /// <summary>
    /// 고정 재료 리스트
    /// </summary>
    private List<FixIngredientData> correctFixIngredientList = new();
    /// <summary>
    /// 랜덤 재료 리스트
    /// </summary>
    private List<RandomIngredientQuantity> correctRandomIngredientList = new();

    /// <summary>
    /// 스크립터블 오브젝트로부터 받은 정보 가져오기 위한 객체 생성
    /// </summary>
    public CustomerDataControl customerDataControl;

    /// <summary>
    /// 버튼을 눌렀을 때 올바른 레시피인지 판단
    /// </summary>
    private bool isCorrect;

    /// <summary>
    /// 요리 완성 쟁반 가리는 시간
    /// </summary>
    public float fadeDuration = 1.5f;
    /// <summary>
    /// 패널 alpha 값 변경하기 위한 객체
    /// </summary>
    public GameObject whiteScreen;
    /// <summary>
    /// 패널에 붙은 이미지 컴포넌트 조작하기 위한 객체
    /// </summary>
    private Image whiteScreenImage;
    /// <summary>
    /// 초기 불투명한 패널 상태로 변경하기 위한 객체
    /// </summary>
    private Color originWhiteScreenColor;

    /// <summary>
    /// 요리 완성 시 쟁반에 생기는 음식 프리팹
    /// </summary>
    public GameObject completeIngredientPrefab;
    /// <summary>
    /// 쟁반 RectTransform 컴포넌트
    /// </summary>
    public RectTransform completeSlot;

    /// <summary>
    /// 요리 항아리 RectTransform 컴포넌트
    /// </summary>
    public RectTransform cookingSlot;

    /// <summary>
    /// 요리 애니메이션 재생을 버튼으로 컨트롤하기 위한 객체
    /// </summary>
    public CookingControl cookingControl;

    /// <summary>
    /// 드롭되는 재료 정보 가져오기 위한 객체
    /// </summary>
    public IngredientDroppable ingredientDroppable;

    private void Awake()
    {
        // 컴포넌트 연결
        whiteScreenImage = whiteScreen.GetComponent<Image>();
        // 초기 패널 색상
        originWhiteScreenColor = whiteScreenImage.color;
        // 초기 값 설정
        setup();
        // 올바른 레시피 정보 등록
        setList();
    }

    void Update()
    {
        // 요리 완성 판정
        cookFinishAndMove();
    }

    private void setup()
    {
        isCorrect = false;
        whiteScreenImage.color = originWhiteScreenColor;
    }

    public void setList()
    {
        // CookingCheck 스크립트가 2군데 있어서 1번만 리스트 정보 세팅되게끔 조건 설정
        if (this.gameObject.name == "Cook Start Button")
        {
            // 쿠킹 매니저로부터 손님 인덱스 가져옴
            // 씬이 변경되더라도 인덱스가 유지되게 하여 다음 손님 정보 가져올 수 있도록 세팅
            int index = CookingGameManager.Instance.getCookingCustomerIndex();
            // 현재 인덱스 확인
            Debug.Log(index);
            // 손님 스크립터블 데이터 가져옴
            // 앞서 설정한 인덱스를 기준으로 여러 손님 데이터 중에 골라옴
            CustomerData customerData = customerDataControl.customerData[index];
            // 고정 재료 리스트 가져옴
            List<FixIngredientData> ingredientData = customerData.order.fixedIngredients;
            // 랜덤 재료 리스트 가져옴
            List<RandomIngredientQuantity> ingredientQuantities = customerData.order.randomingredients;

            // CookingCheck 내부에서 처리가능하도록 전체 값 복사
            correctFixIngredientList.AddRange(ingredientData);
            correctRandomIngredientList.AddRange(ingredientQuantities);
            // 어떤 레시피 재료 들어왔는지 확인
            foreach (FixIngredientData ingredientData1 in correctFixIngredientList)
            {
                Debug.Log(ingredientData1.ingredient_amount);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void cookFinishAndMove()
    {
        // 요리 완성되었을 때 판정
        if (isCorrect)
        {
            // 좌클릭 눌렀을 때
            if (Input.GetMouseButtonDown(0))
            {
                // 마우스 ray 체크
                RaycastHit hit = CastRay();
                // 완성된 요리 프리팹으로부터 인스턴스 생성
                GameObject newObj = Instantiate(completeIngredientPrefab, completeSlot);
                // 인스턴스 위치 설정
                newObj.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                // 최상단에 노출되도록 위치 설정
                newObj.transform.SetAsFirstSibling();
                // 코루틴으로 페이드 아웃 설정
                StartCoroutine(fadeOutWhiteScreen());
                // 초기값 다시 설정
                setup();
                // 항아리 비어있는지 채워져있는지
                cookingControl.setFullEmpty(false);
                // 비어있는 항아리 애니메이션 실행
                cookingControl.playEmptyAnimation();
            }
        }
    }

    private IEnumerator fadeOutWhiteScreen()
    {
        Color startColor = whiteScreenImage.color;
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsed / fadeDuration);
            whiteScreenImage.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            yield return null;
        }
        whiteScreenImage.color = new Color(startColor.r, startColor.g, startColor.b, 0f);
        whiteScreen.SetActive(false);
        Debug.Log("요리 완성 페이드 아웃");
    }

    private RaycastHit CastRay()
    {
        Vector2 screenMousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldMousePos = Camera.main.ScreenToWorldPoint(screenMousePos);
        RaycastHit hit;
        Physics.Raycast(screenMousePos, worldMousePos, out hit);
        return hit;
    }

    private bool checkIngredientList()
    {
        List<string> ingredientDropName = ingredientDroppable.getIngredientName();
        int correctCount = 0;
        bool check = false;
        int i = 0;
        int k = 0;
        bool iFlag = true;
        bool kFlag = true;
        while (true)
        {
            Debug.Log("고정 가짓수" + correctFixIngredientList.Count + ", 랜덤 가짓수" + correctRandomIngredientList.Count);
            if (iFlag == false && kFlag == false)
            {
                if (correctCount == correctFixIngredientList.Count + correctRandomIngredientList.Count)
                {
                    check = true;
                    break;
                }
                else
                {
                    check = false;
                    break;
                }
            }
            if (i >= correctFixIngredientList.Count)
            {
                iFlag = false;
            }
            if (k >= correctRandomIngredientList.Count)
            {
                kFlag = false;
            }

            if (iFlag)
            {
                if (ingredientDropName.Contains(correctFixIngredientList[i].ingredient_name))
                {
                    string containName = correctFixIngredientList[i].ingredient_name;
                    int containCount = 0;
                    for (int j = 0; j < ingredientDropName.Count; j++)
                    {
                        if (containName == ingredientDropName[j])
                            containCount++;
                    }
                    if (containCount == correctFixIngredientList[i].ingredient_amount)
                    {
                        correctCount++;
                    }
                }
            }
            if (kFlag)
            {
                if (ingredientDropName.Contains(correctRandomIngredientList[k].ingredient.ingredient_name))
                {
                    string containName = correctRandomIngredientList[k].ingredient.ingredient_name;
                    int containCount = 0;
                    for (int j = 0; j < ingredientDropName.Count; j++)
                    {
                        if (containName == ingredientDropName[j])
                            containCount++;
                    }
                    if (containCount == correctRandomIngredientList[k].amount)
                    {
                        correctCount++;
                    }
                }
            }
            i++;
            k++;
        }
        return check;
    }

    public void OnClickFinish()
    {
        if (ingredientDroppable.getIngredientName().Count > 0)
        {
            isCorrect = checkIngredientList();

            cookingControl.setSuccess(isCorrect);
            cookingControl.setFullEmpty(true);
            foreach (Transform child in cookingSlot.transform)
            {
                if (child.CompareTag("Ingredient"))
                {
                    child.gameObject.SetActive(false);
                    Destroy(child.gameObject);
                }
            }

            if (isCorrect)
            {
                // 완성된 재료 프리팹을 생성해서 completeSlot에 붙임
                Debug.Log("요리 완성");
            }

            else
            {
                Debug.Log("이걸 요리라고 만든건가?");
                ingredientDroppable.setIngredientClear();
            }
        }
    }

    public void setCorrect(bool correct)
    {
        isCorrect = correct;
    }

    public bool getCorrect()
    {
        return isCorrect;
    }

}
