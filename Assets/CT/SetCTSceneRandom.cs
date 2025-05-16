using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetCTSceneRandom : MonoBehaviour
{
    public GameObject randomObejct;
    public List<Text> ingredientCountText;
    public List<CustomerData> randomIngredient;
    private void Start()
    {
        setCustomerIngredientCount();
    }

    private void setCustomerIngredientCount()
    {
        randomObejct.SetActive(false);
        int index = CookingGameManager.Instance.getCookingCustomerIndex();
        // 현재 인덱스 확인
        Debug.Log(index);
        // 손님 스크립터블 데이터 가져옴
        // 앞서 설정한 인덱스를 기준으로 여러 손님 데이터 중에 골라옴
        // 랜덤 재료 리스트 가져옴
        List<RandomIngredientQuantity> ingredientQuantities = randomIngredient[index].order.randomingredients;
        for (int i = 0; i < ingredientQuantities.Count; i++)
        {
            string countText = "";
            if (ingredientQuantities[i].ingredient.ingredient_name == "Special1")
            {
                int countSpecial1 = ingredientQuantities[i].amount;
                countText = countText + countSpecial1.ToString();
                ingredientCountText[0].text = countText;
            }
            else if (ingredientQuantities[i].ingredient.ingredient_name == "Special2")
            {
                int countSpecial2 = ingredientQuantities[i].amount;
                countText = countText + countSpecial2.ToString();
                ingredientCountText[1].text = countText;
            }
            else if (ingredientQuantities[i].ingredient.ingredient_name == "Special3")
            {
                int countSpecial3 = ingredientQuantities[i].amount;
                countText = countText + countSpecial3.ToString();
                ingredientCountText[2].text = countText;
            }
        }
    }
}


