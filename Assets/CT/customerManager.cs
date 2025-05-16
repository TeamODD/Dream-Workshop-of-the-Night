using UnityEngine;
using UnityEngine.SceneManagement;
public class customerManager : MonoBehaviour
{
    void start()
    {
        PlayerPrefs.SetInt("Customer", 0);
        PlayerPrefs.Save();
    }
    
    public void LoadSceneByName()
    {
        SceneManager.LoadScene("CT");
    }
}
