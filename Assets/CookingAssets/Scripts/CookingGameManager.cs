using UnityEngine;
using UnityEngine.UI;

public class CookingGameManager : MonoBehaviour
{
    private static CookingGameManager instance = null;
    public static CookingGameManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }

    public static int cookingCustomerIndex = 0;
    public static int cookingSceneChange = 1;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        //cookingCustomerIndex = 0;
    }

    public void setCookingSceneIndex()
    {
        cookingSceneChange = cookingSceneChange + 2;
    }


    public void setCTIndex(int index)
    {
        cookingCustomerIndex = index;
    }
    public int getCookingCustomerIndex()
    {
        return cookingCustomerIndex;
    }
}
