using UnityEngine;
using UnityEngine.UI;

public class CustomerDialogue : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialogueText;
    public MoveObjectUpDown moveScript; // 대화창 패널에 연결된 이동 스크립트

    private System.Action onDialogueClicked;

    void Awake()
    {
        if (moveScript == null)
        {
            moveScript = GetComponent<MoveObjectUpDown>();
        }
        dialoguePanel.SetActive(false); // 시작 시 비활성화
    }

    public void ShowDialogue(string message, System.Action callback)
    {
        dialogueText.text = message;
        // 대화창이 화면에 나타날 위치 설정
        float targetY = 200f; // 캔버스 상의 적절한 위치로 조정
        moveScript.MoveUp(targetY, null); // 대화창은 클릭 시 사라지므로 이동 완료 콜백은 없음

        onDialogueClicked = callback;
    }

    public void OnDialogueClick()
    {
        if (moveScript != null && !moveScript.IsMoving())
        {
            dialoguePanel.SetActive(false); // 그냥 사라지게
            onDialogueClicked?.Invoke();    // 다음 흐름 실행
        }
    }


}   
