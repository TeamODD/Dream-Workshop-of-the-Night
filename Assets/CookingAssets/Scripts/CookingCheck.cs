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
    /// ���� ��� ����Ʈ
    /// </summary>
    private List<FixIngredientData> correctFixIngredientList = new();
    /// <summary>
    /// ���� ��� ����Ʈ
    /// </summary>
    private List<RandomIngredientQuantity> correctRandomIngredientList = new();

    /// <summary>
    /// ��ũ���ͺ� ������Ʈ�κ��� ���� ���� �������� ���� ��ü ����
    /// </summary>
    public CustomerDataControl customerDataControl;

    /// <summary>
    /// ��ư�� ������ �� �ùٸ� ���������� �Ǵ�
    /// </summary>
    private bool isCorrect;

    /// <summary>
    /// �丮 �ϼ� ��� ������ �ð�
    /// </summary>
    public float fadeDuration = 1.5f;
    /// <summary>
    /// �г� alpha �� �����ϱ� ���� ��ü
    /// </summary>
    public GameObject whiteScreen;
    /// <summary>
    /// �гο� ���� �̹��� ������Ʈ �����ϱ� ���� ��ü
    /// </summary>
    private Image whiteScreenImage;
    /// <summary>
    /// �ʱ� �������� �г� ���·� �����ϱ� ���� ��ü
    /// </summary>
    private Color originWhiteScreenColor;

    /// <summary>
    /// �丮 �ϼ� �� ��ݿ� ����� ���� ������
    /// </summary>
    public GameObject completeIngredientPrefab;
    /// <summary>
    /// ��� RectTransform ������Ʈ
    /// </summary>
    public RectTransform completeSlot;

    /// <summary>
    /// �丮 �׾Ƹ� RectTransform ������Ʈ
    /// </summary>
    public RectTransform cookingSlot;

    /// <summary>
    /// �丮 �ִϸ��̼� ����� ��ư���� ��Ʈ���ϱ� ���� ��ü
    /// </summary>
    public CookingControl cookingControl;

    /// <summary>
    /// ��ӵǴ� ��� ���� �������� ���� ��ü
    /// </summary>
    public IngredientDroppable ingredientDroppable;

    private void Awake()
    {
        // ������Ʈ ����
        whiteScreenImage = whiteScreen.GetComponent<Image>();
        // �ʱ� �г� ����
        originWhiteScreenColor = whiteScreenImage.color;
        // �ʱ� �� ����
        setup();
        // �ùٸ� ������ ���� ���
        setList();
    }

    void Update()
    {
        // �丮 �ϼ� ����
        cookFinishAndMove();
    }

    private void setup()
    {
        isCorrect = false;
        whiteScreenImage.color = originWhiteScreenColor;
    }

    public void setList()
    {
        // CookingCheck ��ũ��Ʈ�� 2���� �־ 1���� ����Ʈ ���� ���õǰԲ� ���� ����
        if (this.gameObject.name == "Cook Start Button")
        {
            // ��ŷ �Ŵ����κ��� �մ� �ε��� ������
            // ���� ����Ǵ��� �ε����� �����ǰ� �Ͽ� ���� �մ� ���� ������ �� �ֵ��� ����
            int index = CookingGameManager.Instance.getCookingCustomerIndex();
            // ���� �ε��� Ȯ��
            Debug.Log(index);
            // �մ� ��ũ���ͺ� ������ ������
            // �ռ� ������ �ε����� �������� ���� �մ� ������ �߿� ����
            CustomerData customerData = customerDataControl.customerData[index];
            // ���� ��� ����Ʈ ������
            List<FixIngredientData> ingredientData = customerData.order.fixedIngredients;
            // ���� ��� ����Ʈ ������
            List<RandomIngredientQuantity> ingredientQuantities = customerData.order.randomingredients;

            // CookingCheck ���ο��� ó�������ϵ��� ��ü �� ����
            correctFixIngredientList.AddRange(ingredientData);
            correctRandomIngredientList.AddRange(ingredientQuantities);
            // � ������ ��� ���Դ��� Ȯ��
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
        // �丮 �ϼ��Ǿ��� �� ����
        if (isCorrect)
        {
            // ��Ŭ�� ������ ��
            if (Input.GetMouseButtonDown(0))
            {
                // ���콺 ray üũ
                RaycastHit hit = CastRay();
                // �ϼ��� �丮 ���������κ��� �ν��Ͻ� ����
                GameObject newObj = Instantiate(completeIngredientPrefab, completeSlot);
                // �ν��Ͻ� ��ġ ����
                newObj.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                // �ֻ�ܿ� ����ǵ��� ��ġ ����
                newObj.transform.SetAsFirstSibling();
                // �ڷ�ƾ���� ���̵� �ƿ� ����
                StartCoroutine(fadeOutWhiteScreen());
                // �ʱⰪ �ٽ� ����
                setup();
                // �׾Ƹ� ����ִ��� ä�����ִ���
                cookingControl.setFullEmpty(false);
                // ����ִ� �׾Ƹ� �ִϸ��̼� ����
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
        Debug.Log("�丮 �ϼ� ���̵� �ƿ�");
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
            Debug.Log("���� ������" + correctFixIngredientList.Count + ", ���� ������" + correctRandomIngredientList.Count);
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
                // �ϼ��� ��� �������� �����ؼ� completeSlot�� ����
                Debug.Log("�丮 �ϼ�");
            }

            else
            {
                Debug.Log("�̰� �丮��� ����ǰ�?");
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
