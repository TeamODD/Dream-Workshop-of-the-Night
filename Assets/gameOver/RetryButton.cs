using UnityEngine;
using UnityEngine.SceneManagement;
public class RetryButton : MonoBehaviour
{
    public void selectRetry()
    {
        SceneManager.LoadScene("SelectLevel");
    }
    
}
