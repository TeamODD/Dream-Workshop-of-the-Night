using UnityEngine;
using UnityEngine.UI;
using System.Collections; // <-- �� ���� �߰��ؾ� �մϴ�.

public class CustomerReactionUI : MonoBehaviour
{
    public GameObject resultDialoguePanel;
    public Text resultDialogueText;
    public MoveObjectUpDown moveScript; // ���� ��� �гο� ����� �̵� ��ũ��Ʈ

    public string successDialogue = "���� ������!";
    public string failureDialogue = ".....";
    public float displayDuration = 2f;

    void Awake()
    {
        if (moveScript == null)
        {
            moveScript = GetComponent<MoveObjectUpDown>();
        }
        resultDialoguePanel.SetActive(false); // ���� �� ��Ȱ��ȭ
    }

    public void ShowResult(bool isSuccess, System.Action onHiddenCallback = null)
    {
        if (isSuccess)
        {
            resultDialogueText.text = successDialogue;
        }
        else
        {
            resultDialogueText.text = failureDialogue;
        }

        // ���� ���â�� ȭ�鿡 ��Ÿ�� ��ġ ����
        float targetY = 300f; // ĵ���� ���� ������ ��ġ�� ����
        moveScript.MoveUp(targetY, () => StartCoroutine(HideAfterDelay(displayDuration, onHiddenCallback)));
    }

    IEnumerator HideAfterDelay(float delay, System.Action onHiddenCallback)
    {
        yield return new WaitForSeconds(delay);
        moveScript.MoveDown(onHiddenCallback);
    }
}