using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadSelectLevel : MonoBehaviour
{
    public Image backgroundImage;
    public Sprite newBackgroundSprite;
    public void selectLevel()
    {   
        backgroundImage.sprite = newBackgroundSprite;
        Invoke("LoadselectLevel", 1f);
    }
    void LoadselectLevel()
    {
        SceneManager.LoadScene("SelectLevel");
    }
}