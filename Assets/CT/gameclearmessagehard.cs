using UnityEngine;
using UnityEngine.SceneManagement;

public class gameclearmessagehard : MonoBehaviour
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
            customerUP.is_1 = false;
            customerUP.is_2 = false;
            customerUP.is_3 = false;
            randomreciUP.food_ok = false;
            Invoke("LoadSelect", 3f);
            PlayerPrefs.SetInt("EasyClear", 1);
            PlayerPrefs.Save();
            CookingGameManager.cookingCustomerIndex = 0;
            CookingGameManager.cookingSceneChange++;
        }
    }

    void LoadSelect()
    {
        SceneManager.LoadScene("main");
    }
}
