using UnityEngine;
using System.Collections;

public class CustomerCharacter : MonoBehaviour
{
    public MoveObjectUpDown moveScript;
    public float entryYTarget = 0f;
    public float exitYTarget = -500f;
    public float dialogueDelay = 0.5f; // 대사창 표시 지연 시간 (초)

    private System.Action onEnteredCallback;

    void Awake()
    {
        if (moveScript == null) moveScript = GetComponent<MoveObjectUpDown>();
        gameObject.SetActive(false);
    }

    public void Enter(System.Action callback = null)
    {
        gameObject.SetActive(true);
        onEnteredCallback = callback;
        moveScript.MoveUp(entryYTarget, OnMoveUpFinished);
    }

    void OnMoveUpFinished()
    {
        StartCoroutine(ShowDialogueDelayed());
    }

    IEnumerator ShowDialogueDelayed()
    {
        yield return new WaitForSeconds(dialogueDelay);
        onEnteredCallback?.Invoke();
    }

    public void Exit(System.Action callback = null)
    {
        moveScript.MoveDown(callback);
    }

    public void SetSprite(Sprite sprite)
    {
        GetComponent<UnityEngine.UI.Image>().sprite = sprite;
    }
}