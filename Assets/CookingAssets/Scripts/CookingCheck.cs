using System.Collections.Generic;
using UnityEngine;

public class CookingCheck : MonoBehaviour
{
    public List<string> inputIngredientList { get; set; }
    private List<string> correctIngredientList;

    private void Awake()
    {
        correctIngredientList.Add("Milk");
        correctIngredientList.Add("Butter");
        correctIngredientList.Add("Egg");
        correctIngredientList.Sort();
    }


}
