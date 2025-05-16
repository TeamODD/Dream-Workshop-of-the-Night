using UnityEngine;

public class gameclearmessage : MonoBehaviour
{
    public GameObject clearpanel;
    private void Start()
    {
        clearpanel.SetActive(false);
    }
    void Update()
    {
        //if (recipeUP.customerNum == 4)
        //{
        //    clearpanel.SetActive(true);
        //    recipeUP.customerNum = 0;
        //}
        if (CookingGameManager.cookingCustomerIndex == 4)
        {
            clearpanel.SetActive(true);
            CookingGameManager.cookingCustomerIndex = 0;
            CookingGameManager.cookingSceneChange++;
        }
    }
}
