using UnityEngine;

[CreateAssetMenu(fileName = "IngredientQuantity", menuName = "Scriptable Objects/IngredientQuantity")]
public class IngredientQuantity : ScriptableObject
{
    public IngredientData ingredient;
    public int minAmount;
    public int maxAmount;
    public int amount;
}
