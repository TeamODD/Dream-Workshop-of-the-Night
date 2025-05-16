using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class randomreciUP : MonoBehaviour
{
    public RectTransform recipepaper;
    public float animationDuration = 0.5f;
    public Vector2 targetPosition;
    private Vector2 startPosition;
    private Coroutine currentCoroutine;
    public GameObject okButton;
    public static bool food_ok = false;
    public GameObject pixrecipe;
    public GameObject randrecipe;
    public AudioSource audioSource;
    void Start()
    {
        startPosition = new Vector2(targetPosition.x, -Screen.height);
        recipepaper.anchoredPosition = startPosition;
    }
    public void MoveUp()
    {
        okButton.SetActive(false);
        pixrecipe.SetActive(false);
        randrecipe.SetActive(true);
        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);
        currentCoroutine = StartCoroutine(AnimatePanel(targetPosition));
    }
    public void MoveDown()
    {
        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);
        currentCoroutine = StartCoroutine(AnimatePanel(startPosition));
        food_ok = true;
        SceneManager.LoadScene("CookingScene");
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
            audioSource.Play();
            yield return new WaitForSeconds(3f);
            StartCoroutine(AnimatePanel(startPosition));
        }
        else if (destination == startPosition)
        {
            food_ok = true;
            SceneManager.LoadScene("CookingScene");
        }
    }
}