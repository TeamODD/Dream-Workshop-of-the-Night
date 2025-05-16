using UnityEngine;

[CreateAssetMenu(fileName = "IngredientQuantity", menuName = "Scriptable Objects/IngredientQuantity")]
public class IngredientQuantity1 : ScriptableObject
{
    public IngredientData1 ingredient;
    public int minAmount;
    public int maxAmount;
    public int Amount;
}
