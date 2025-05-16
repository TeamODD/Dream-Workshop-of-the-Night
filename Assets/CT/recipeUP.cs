using UnityEngine;
using System.Collections;
public class recipeUP : MonoBehaviour
{
    public RectTransform recipepaper;
    public float animationDuration = 0.5f;
    public Vector2 targetPosition;
    private Vector2 startPosition;
    private Coroutine currentCoroutine;
    //public static int customerNum = 0;
    void Start()
    {
        startPosition = new Vector2(targetPosition.x, -Screen.height);
        recipepaper.anchoredPosition = startPosition;
        //if (customerNum == 0)
        //    MoveUp();
        if (CookingGameManager.cookingCustomerIndex == 0)
            MoveUp();
    }
    public void MoveUp()
    {
        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);
        currentCoroutine = StartCoroutine(AnimatePanel(targetPosition));
    }
    public void MoveDown()
    {
        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);
        currentCoroutine = StartCoroutine(AnimatePanel(startPosition));
        //customerNum = 1;
        CookingGameManager.cookingCustomerIndex = 1;
    }
    IEnumerator AnimatePanel(Vector2 destination)
    {
        float elapsed = 0f;
        Vector2 initialPosition = recipepaper.anchoredPosition;

        while (elapsed < animationDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / animationDuration);
            recipepaper.anchoredPosition = Vector2.Lerp(initialPosition, destination, t);
            yield return null;
        }

        recipepaper.anchoredPosition = destination;
        if (destination == targetPosition)
        {
            yield return new WaitForSeconds(3f);
            MoveDown();
        }
    }
}