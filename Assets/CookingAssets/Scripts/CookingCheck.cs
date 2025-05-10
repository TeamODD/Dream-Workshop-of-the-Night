using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static IngredientData;

public class CookingCheck : MonoBehaviour
{
    public static List<IngredientType> inputIngredientList = new();
    private List<IngredientType> correctIngredientList = new();

    public GameObject completeIngredientPrefab;
    public RectTransform completeSlot;

    private void Awake()
    {
        correctIngredientList.Add(IngredientType.Butter);
        correctIngredientList.Add(IngredientType.Milk);
        correctIngredientList.Add(IngredientType.Egg);
        correctIngredientList.Sort();
    }
    

    public void OnClickFinish()
    {
        inputIngredientList.Sort();
        bool isCorrect = inputIngredientList.SequenceEqual(correctIngredientList);

        if (isCorrect)
        {
            foreach (Transform child in transform)
            {
                if (child.CompareTag("Ingredient"))
                {
                    Debug.Log("Destroying " + child.name);
                    Destroy(child.gameObject);
                }
            }
            //// 이미 자식이 있다면 지움 (선택사항)
            //foreach (RectTransform child in completeSlot)
            //{
            //    Destroy(child.gameObject);
            //}

            // 완성된 재료 프리팹을 생성해서 completeSlot에 붙임
            GameObject newObj = Instantiate(completeIngredientPrefab, completeSlot);
            newObj.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        }
        else
        {
            inputIngredientList.Clear();

        }
    }
}
