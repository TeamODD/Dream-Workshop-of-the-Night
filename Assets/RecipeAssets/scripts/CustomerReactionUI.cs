using UnityEngine;
using UnityEngine.UI;
using System.Collections; // <-- 이 줄을 추가해야 합니다.

public class CustomerReactionUI : MonoBehaviour
{
    public GameObject resultDialoguePanel;
    public Text resultDialogueText;
    public MoveObjectUpDown moveScript; // 반응 대사 패널에 연결된 이동 스크립트

    public string successDialogue = "정말 고마워요!";
    public string failureDialogue = ".....";
    public float displayDuration = 2f;

    void Awake()
    {
        if (moveScript == null)
        {
            moveScript = GetComponent<MoveObjectUpDown>();
        }
        resultDialoguePanel.SetActive(false); // 시작 시 비활성화
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

        // 반응 대사창이 화면에 나타날 위치 설정
        float targetY = 300f; // 캔버스 상의 적절한 위치로 조정
        moveScript.MoveUp(targetY, () => StartCoroutine(HideAfterDelay(displayDuration, onHiddenCallback)));
    }

    IEnumerator HideAfterDelay(float delay, System.Action onHiddenCallback)
    {
        yield return new WaitForSeconds(delay);
        moveScript.MoveDown(onHiddenCallback);
    }
}