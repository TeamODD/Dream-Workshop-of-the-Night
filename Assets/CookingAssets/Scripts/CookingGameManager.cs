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
        cookingCustomerIndex = 0;
    }

    public void setCookingCustomerIndex()
    {
        cookingCustomerIndex++;
    }

    public int getCookingCustomerIndex()
    {
        return cookingCustomerIndex;
    }
}
