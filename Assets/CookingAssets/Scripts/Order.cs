using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Order
{
    public List<FixIngredientData> fixedIngredients;
    public List<RandomIngredientQuantity> randomingredients;
}