using UnityEngine;

[CreateAssetMenu(fileName = "IngredientQuantity", menuName = "Scriptable Objects/IngredientQuantity")]
public class RandomIngredientQuantity : ScriptableObject
{
    public FixIngredientData ingredient;
    public int minAmount;
    public int maxAmount;
    public int amount;
}
