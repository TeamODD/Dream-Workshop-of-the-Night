using UnityEngine;

public class selectActive : MonoBehaviour
{
    public GameObject NormalButton;
    public GameObject HardButton;
    void Start()
    {
        int clearEasy = PlayerPrefs.GetInt("EasyClear", 0);
        int clearNormal = PlayerPrefs.GetInt("NormalClear", 0);
        NormalButton.SetActive(false);
        HardButton.SetActive(false);
        if (clearEasy==1)
        {
            NormalButton.SetActive(true);
        }

        if (clearNormal==1)
        {
            HardButton.SetActive(true);
        }
    }
}
