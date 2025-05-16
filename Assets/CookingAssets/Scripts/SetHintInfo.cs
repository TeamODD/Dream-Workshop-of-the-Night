using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class SetHintInfo : MonoBehaviour
{
    public List<Text> ingredientCountText;
    public CustomerDataControl customerDataControl;

    private void Start()
    {
        setCustomerIngredientCount();
    }

    private void setCustomerIngredientCount()
    {
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
        for (int i = 0; i < ingredientData.Count; i++)
        {
            string countText = "Need\nX";
            if (ingredientData[i].ingredient_name == "Egg")
            {
                int countEgg = ingredientData[i].ingredient_amount;
                countText = countText + countEgg.ToString();
                ingredientCountText[0].text = countText;
            }
            else if (ingredientData[i].ingredient_name == "Butter")
            {
                int countButter = ingredientData[i].ingredient_amount;
                countText = countText + countButter.ToString();
                ingredientCountText[1].text = countText;
            }
            else if (ingredientData[i].ingredient_name == "Sugar")
            {
                int countSugar = ingredientData[i].ingredient_amount;
                countText = countText + countSugar.ToString();
                ingredientCountText[2].text = countText;
            }
        }
        for (int i = 0; i < ingredientQuantities.Count; i++)
        {
            string countText = "Need\nX";
            if (ingredientQuantities[i].ingredient.ingredient_name == "Special1")
            {
                int countSpecial1 = ingredientQuantities[i].amount;
                countText = countText + countSpecial1.ToString();
                ingredientCountText[3].text = countText;
            }
            else if (ingredientQuantities[i].ingredient.ingredient_name == "Special2")
            {
                int countSpecial2 = ingredientQuantities[i].amount;
                countText = countText + countSpecial2.ToString();
                ingredientCountText[4].text = countText;
            }
            else if (ingredientQuantities[i].ingredient.ingredient_name == "Special3")
            {
                int countSpecial3 = ingredientQuantities[i].amount;
                countText = countText + countSpecial3.ToString();
                ingredientCountText[5].text = countText;
            }
        }
    }
}
