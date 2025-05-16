using UnityEngine;
using UnityEngine.SceneManagement;

public class selectLevel : MonoBehaviour
{
    public void SelectEasy()
    {
        SceneManager.LoadScene("CT");
    }
    public void SelectNormal()
    {
        SceneManager.LoadScene("CTNormal");
    }
    public void SelectHard()
    {
        SceneManager.LoadScene("CTHard");
    }
}
