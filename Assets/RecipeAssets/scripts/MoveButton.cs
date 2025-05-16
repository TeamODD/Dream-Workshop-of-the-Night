using UnityEngine;
using System.Collections;
public class MoveButton : MonoBehaviour
{
    public RectTransform RulesPanel;
    public float animationDuration = 0.5f;
    public Vector2 targetPosition;
    private Vector2 startPosition;
    private Coroutine currentCoroutine;

    void Start()
    {
        startPosition = new Vector2(targetPosition.x, -Screen.height);
        RulesPanel.anchoredPosition = startPosition;
        SelectRules();
    }
    public void SelectRules()
    {
        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);
        currentCoroutine = StartCoroutine(AnimatePanel(targetPosition));
    }
    public void SelectExit()
    {
        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);
        currentCoroutine = StartCoroutine(AnimatePanel(startPosition));
    }
    IEnumerator AnimatePanel(Vector2 destination)
    {
        float elapsed = 0f;
        Vector2 initialPosition = RulesPanel.anchoredPosition;

        while (elapsed < animationDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / animationDuration);
            RulesPanel.anchoredPosition = Vector2.Lerp(initialPosition, destination, t);
            yield return null;
        }

        RulesPanel.anchoredPosition = destination;
        
    }
}
