using UnityEngine;
using UnityEngine.SceneManagement;

public class selectLevel : MonoBehaviour
{
    public void SelectEasy()
    {
        CookingGameManager.cookingSceneCustomerIndex = 1;
        customerUP.is_1 = false;
        customerUP.is_2 = false;
        customerUP.is_3 = false;
        randomreciUP.food_ok = false;
        SceneManager.LoadScene("CTEasy");
    }
    public void SelectNormal()
    {
        CookingGameManager.cookingSceneCustomerIndex = 4;
        customerUP.is_1 = false;
        customerUP.is_2 = false;
        customerUP.is_3 = false;
        randomreciUP.food_ok = false;
        SceneManager.LoadScene("CTNormal");
    }
    public void SelectHard()
    {
        CookingGameManager.cookingSceneCustomerIndex = 7;
        customerUP.is_1 = false;
        customerUP.is_2 = false;
        customerUP.is_3 = false;
        randomreciUP.food_ok = false;
        SceneManager.LoadScene("CTHard");
    }
}
