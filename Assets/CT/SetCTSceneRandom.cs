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
        // ���� �ε��� Ȯ��
        Debug.Log(index);
        // �մ� ��ũ���ͺ� ������ ������
        // �ռ� ������ �ε����� �������� ���� �մ� ������ �߿� ����
        // ���� ��� ����Ʈ ������
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


