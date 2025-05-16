using UnityEngine;
using UnityEngine.UI;

public class OneTimeButton : MonoBehaviour
{
    private Button button;
    private bool alreadyClicked = false;

    void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClicked);
    }

    void OnClicked()
    {
        if (alreadyClicked) return; 
        alreadyClicked = true;

        Debug.Log("처음 한 번만 실행됨!");

        // 여기에 원하는 동작 추가
        GameManager.Instance.OnFixedRecipeHidden(); 
    }
}
