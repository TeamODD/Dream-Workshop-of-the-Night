using UnityEngine;
using System.Collections;

public class MoveObjectUpDown : MonoBehaviour
{
    public float moveSpeed = 500f;
    public float startYPosition;
    public float targetYPosition;
    public float hideYPosition;

    private RectTransform rectTransform;
    private Vector3 initialPosition;
    private bool isMoving = false;
    public System.Action OnMovementFinished;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        if (rectTransform != null) { }
        else { initialPosition = transform.position; }
    }

    public void InitializePositions(float startY, float hideY)
    {
        startYPosition = startY;
        hideYPosition = hideY;

        if (rectTransform != null)
        {
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, hideYPosition);
            gameObject.SetActive(false);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, hideYPosition, transform.position.z);
            gameObject.SetActive(false);
        }
    }

    public void MoveUp(float targetY, System.Action callback = null)
    {
        gameObject.SetActive(true);
        targetYPosition = targetY;
        OnMovementFinished = callback;
        StartCoroutine(DoMove(targetYPosition));
    }

    public void MoveDown(System.Action callback = null)
    {
        OnMovementFinished = callback;
        StartCoroutine(DoMove(hideYPosition));
    }

    IEnumerator DoMove(float targetY)
    {
        isMoving = true;
        float currentY = (rectTransform != null) ? rectTransform.anchoredPosition.y : transform.position.y;

        while (Mathf.Abs(currentY - targetY) > 10f)
        {
            currentY = Mathf.MoveTowards(currentY, targetY, moveSpeed * Time.deltaTime);
            if (rectTransform != null) rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, currentY);
            else transform.position = new Vector3(transform.position.x, currentY, transform.position.z);
            yield return null;
        }

        if (rectTransform != null) rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, targetY);
        else transform.position = new Vector3(transform.position.x, targetY, transform.position.z);

        isMoving = false;
        OnMovementFinished?.Invoke();
        if (targetY == hideYPosition) gameObject.SetActive(false);
    }

    public bool IsMoving() { return isMoving; }
}