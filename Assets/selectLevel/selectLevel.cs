using UnityEngine;
using UnityEngine.SceneManagement;

public class selectLevel : MonoBehaviour
{
    public void SelectEasy()
    {
        SceneManager.LoadScene("Easy_customer");
    }
    public void SelectNormal()
    {
        SceneManager.LoadScene("Normal_customer");
    }
    public void SelectHard()
    {
        SceneManager.LoadScene("Hard_customer");
    }
}
