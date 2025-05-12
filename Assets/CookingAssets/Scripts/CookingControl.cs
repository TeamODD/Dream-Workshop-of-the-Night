using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// 마법봉 버튼에 넣는 스크립트
/// 항아리에 들어온 재료와 정답 목록 비교
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
        //    Debug.Log("입력" + ingredientType);
        //}
        //foreach (IngredientData.IngredientType ingredientType in IngredientData.correctIngredientList)
        //{
        //    Debug.Log("정답" + ingredientType);
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
            //// 이미 자식이 있다면 지움 (선택사항)
            //foreach (RectTransform child in completeSlot)
            //{
            //    Destroy(child.gameObject);
            //}

            // 완성된 재료 프리팹을 생성해서 completeSlot에 붙임
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
