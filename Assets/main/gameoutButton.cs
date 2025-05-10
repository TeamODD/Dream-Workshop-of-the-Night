using UnityEngine;
using UnityEngine.SceneManagement;

public class gameoutButton : MonoBehaviour
{
    public void selectGameout()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        
#endif
    }
}
