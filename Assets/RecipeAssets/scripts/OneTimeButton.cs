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

        Debug.Log("ó�� �� ���� �����!");

        // ���⿡ ���ϴ� ���� �߰�
        GameManager.Instance.OnFixedRecipeHidden(); 
    }
}
