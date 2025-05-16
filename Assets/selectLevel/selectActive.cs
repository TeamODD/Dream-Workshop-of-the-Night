using UnityEngine;

public class selectActive : MonoBehaviour
{
    public GameObject NormalButton;
    public GameObject HardButton;
    void Start()
    {
        int clearEasy = PlayerPrefs.GetInt("EasyClear", 0);
        int clearNormal = PlayerPrefs.GetInt("NormalClear", 0);
        NormalButton.SetActive(true);
        HardButton.SetActive(true);
        if (clearEasy==1)
        {
            NormalButton.SetActive(false);
        }

        if (clearNormal==1)
        {
            HardButton.SetActive(false);
        }
    }
}
