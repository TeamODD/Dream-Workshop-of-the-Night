using UnityEngine;

public class ClearSave : MonoBehaviour
{
    public void ClearEasy()
    {
        PlayerPrefs.SetInt("EasyClear", 1);
        PlayerPrefs.Save();
    }
    public void ClearNormal()
    {
        PlayerPrefs.SetInt("NormalClear", 1);
        PlayerPrefs.Save();
    }
}
