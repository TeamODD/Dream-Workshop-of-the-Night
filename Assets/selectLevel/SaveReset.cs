using UnityEngine;

public class SaveReset : MonoBehaviour
{
    public void Awake()
    {
        PlayerPrefs.DeleteKey("EasyClear");
        PlayerPrefs.DeleteKey("NormalClear");
        CookingGameManager.cookingSceneChange = 1;
        CookingGameManager.cookingCustomerIndex = 0;
        CookingGameManager.cookingSceneCustomerIndex = 1;
    }

}
