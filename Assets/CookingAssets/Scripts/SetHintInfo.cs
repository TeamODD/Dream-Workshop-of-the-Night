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
        // ���� �ε��� Ȯ��
        Debug.Log(index);
        // �մ� ��ũ���ͺ� ������ ������
        // �ռ� ������ �ε����� �������� ���� �մ� ������ �߿� ����
        CustomerData customerData = customerDataControl.customerData[index];
        // ���� ��� ����Ʈ ������
        List<FixIngredientData> ingredientData = customerData.order.fixedIngredients;
        // ���� ��� ����Ʈ ������
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
