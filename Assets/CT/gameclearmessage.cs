using UnityEngine;
using UnityEngine.SceneManagement;

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
            Invoke("LoadSelect", 3f);
            PlayerPrefs.SetInt("EasyClear", 1);
            PlayerPrefs.Save();
            CookingGameManager.cookingCustomerIndex = 0;
            CookingGameManager.cookingSceneChange++;
        }
    }

    void LoadSelect()
    {
        SceneManager.LoadScene("SelectLevel");
    }
}
