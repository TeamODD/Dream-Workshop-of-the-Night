using UnityEngine;

[CreateAssetMenu(fileName = "FixIngredientData", menuName = "Scriptable Objects/FixIngredientData")]
public class FixIngredientData : ScriptableObject
{
    public string ingredient_name;
    public int ingredient_amount;
    public Sprite picture;
}