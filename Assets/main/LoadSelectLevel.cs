using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSelectLevel : MonoBehaviour
{
    public void selectLevel()
    {
        SceneManager.LoadScene("selectLevel");
    }
}
