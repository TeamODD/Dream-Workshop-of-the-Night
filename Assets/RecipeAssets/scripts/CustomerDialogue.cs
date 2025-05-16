using UnityEngine;
using TMPro; // TextMeshPro ����� ���� ���ӽ����̽�

public class CustomerDialogue : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText; // GameObject �� TextMeshProUGUI �� ����
    public MoveObjectUpDown moveScript;

    private System.Action onDialogueClicked;

    void Awake()
    {
        if (moveScript == null)
        {
            moveScript = GetComponent<MoveObjectUpDown>();
        }
        dialoguePanel.SetActive(false);
    }

    public void ShowDialogue(string message, System.Action callback)
    {
        dialogueText.text = message;
        float targetY = 200f;
        moveScript.MoveUp(targetY, null);
        onDialogueClicked = callback;
    }

    public void OnDialogueClick()
    {
        if (moveScript != null && !moveScript.IsMoving())
        {
            dialoguePanel.SetActive(false);
            onDialogueClicked?.Invoke();
        }
    }
}
