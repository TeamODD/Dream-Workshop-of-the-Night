using UnityEngine;

[CreateAssetMenu(fileName = "IngredientData", menuName = "Scriptable Objects/IngredientData")]
public class FixIngredientData : ScriptableObject
{
    public string ingredient_name;
    public int ingredient_amount;
    public Sprite picture;
}