using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CustomerDataControl : MonoBehaviour
{
    public List<CustomerData> customerData;
    public List<GameObject> fixIngredintPrefab;
    public List<GameObject> randomIngredientPrefab;
    //private CustomerData customerIndex;
    private int characterImageIndex;
    private void Awake()
    {
        //Debug.Log(customerData[0].order.fixedIngredients[0].ingredient_amount);
        //Debug.Log(customerData[0].order.fixedIngredients[1].ingredient_amount);
        //Debug.Log(customerData[0].order.fixedIngredients[2].ingredient_amount);
        //Debug.Log(customerData[0].order.randomingredients[0].amount);
        //Debug.Log(customerData[0].order.randomingredients[1].amount);
        //Debug.Log(customerData[0].order.randomingredients[2].amount);
        setFixIngredient();
        setRandomIngredient();
    }

    private void setFixIngredient()
    {
        for (int i = 0; i < 3; i++)
        {
            //fixIngredintPrefab[i]
        }
    }

    private void setRandomIngredient()
    {

    }

    public void setCharacterImageIndex(int index)
    {
        if (characterImageIndex == 1)
        {
            characterImageIndex = 0;
            customerData[0].characterPrefabIndex = index;
        }
    }

}