using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// ������ ��ư�� �ִ� ��ũ��Ʈ
/// �׾Ƹ��� ���� ���� ���� ��� ��
/// </summary>
public class CookingControl : MonoBehaviour
{
    public GameObject correctCookedFoodPrefab;
    public GameObject wrongCookedFoodPrefab;
    public GameObject cookingSlot;

    private bool isCorrect;// = inputIngredientList.SequenceEqual(correctIngredientList);
    //private List<IngredientType> correctList = new();
    private CookingCheck check;
    private void Awake()
    {
        isCorrect = false;

    }

    public void OnClickCook()
    {

        //inputIngredientList.Sort();
        //bool isCorrect = IngredientData.inputIngredientList.SequenceEqual(IngredientData.correctIngredientList);
        //
        //foreach(IngredientData.IngredientType ingredientType in IngredientData.inputIngredientList)
        //{
        //    Debug.Log("�Է�" + ingredientType);
        //}
        //foreach (IngredientData.IngredientType ingredientType in IngredientData.correctIngredientList)
        //{
        //    Debug.Log("����" + ingredientType);
        //}
        if (isCorrect)
        {
            foreach (Transform child in cookingSlot.transform)
            {
                if (child.CompareTag("Ingredient"))
                {
                    Debug.Log("Destroying " + child.name);
                    child.gameObject.SetActive(false);
                    //Destroy(child.gameObject);
                }
            }
            //// �̹� �ڽ��� �ִٸ� ���� (���û���)
            //foreach (RectTransform child in completeSlot)
            //{
            //    Destroy(child.gameObject);
            //}

            // �ϼ��� ��� �������� �����ؼ� completeSlot�� ����
            //GameObject newObj = Instantiate(completeIngredientPrefab, completeSlot);
            //newObj.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        }
        else
        {
            //inputIngredientList.Clear();
            Debug.Log("?");
        }
    }
}
