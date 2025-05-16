using UnityEngine;
using UnityEngine.UI;

public class CustomerDialogue : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialogueText;
    public MoveObjectUpDown moveScript; // ��ȭâ �гο� ����� �̵� ��ũ��Ʈ

    private System.Action onDialogueClicked;

    void Awake()
    {
        if (moveScript == null)
        {
            moveScript = GetComponent<MoveObjectUpDown>();
        }
        dialoguePanel.SetActive(false); // ���� �� ��Ȱ��ȭ
    }

    public void ShowDialogue(string message, System.Action callback)
    {
        dialogueText.text = message;
        // ��ȭâ�� ȭ�鿡 ��Ÿ�� ��ġ ����
        float targetY = 200f; // ĵ���� ���� ������ ��ġ�� ����
        moveScript.MoveUp(targetY, null); // ��ȭâ�� Ŭ�� �� ������Ƿ� �̵� �Ϸ� �ݹ��� ����

        onDialogueClicked = callback;
    }

    public void OnDialogueClick()
    {
        if (moveScript != null && !moveScript.IsMoving())
        {
            dialoguePanel.SetActive(false); // �׳� �������
            onDialogueClicked?.Invoke();    // ���� �帧 ����
        }
    }


}   
