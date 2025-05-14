using UnityEngine;

[CreateAssetMenu(fileName = "IngredientData", menuName = "Scriptable Objects/IngredientData")]
public class IngredientData : ScriptableObject
{
    public string ingredient_name;
    public float ingredient_amount;
    public Sprite picture;
}