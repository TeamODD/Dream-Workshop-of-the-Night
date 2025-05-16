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

    public static int cookingCustomerIndex;

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
        cookingCustomerIndex = 2;
    }

    public void setCookingCustomerIndex()
    {
        if (cookingCustomerIndex < 8)
        {
            cookingCustomerIndex++;
        }
        else if (cookingCustomerIndex == 8)
        {
            cookingCustomerIndex = 0;
        }
    }

    public int getCookingCustomerIndex()
    {
        return cookingCustomerIndex;
    }
}
