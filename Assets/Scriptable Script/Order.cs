using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Order
{
    public List<IngredientData> fixedIngredients;
    public List<IngredientQuantity> randomingredients;
}