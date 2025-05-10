using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameOver : MonoBehaviour
{
    public void gameOver()
    {
        SceneManager.LoadScene("gameOver");
    }
}
