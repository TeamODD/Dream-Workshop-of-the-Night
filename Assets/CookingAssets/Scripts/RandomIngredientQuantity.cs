using UnityEngine;

[CreateAssetMenu(fileName = "RandomIngredientQuantity", menuName = "Scriptable Objects/RandomIngredientQuantity")]
public class RandomIngredientQuantity : ScriptableObject
{
    public FixIngredientData ingredient;
    public int minAmount;
    public int maxAmount;
    public int amount;
}
