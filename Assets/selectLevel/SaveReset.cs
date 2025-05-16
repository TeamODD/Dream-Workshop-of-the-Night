using UnityEngine;

public class SaveReset : MonoBehaviour
{
    public void selectReset()
    {
        PlayerPrefs.DeleteKey("EasyClear");
        PlayerPrefs.DeleteKey("NormalClear");
        CookingGameManager.cookingSceneChange = 1;
    }
    
}
