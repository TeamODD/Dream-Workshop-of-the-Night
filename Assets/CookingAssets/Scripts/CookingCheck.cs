using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static IngredientData;

/// <summary>
/// 
/// </summary>
public class CookingCheck : MonoBehaviour
{
    public static List<IngredientType> inputIngredientList = new();
    private List<IngredientType> correctIngredientList = new();

    private bool isCorrect;

    public float fadeDuration = 3f;
    public GameObject whiteScreen;
    private Image whiteScreenImage;
    private Color originWhiteScreenColor;

    public GameObject completeIngredientPrefab;
    public RectTransform completeSlot;
    public GameObject correctCookedFoodPrefab;
    public GameObject wrongCookedFoodPrefab;
    public RectTransform cookingSlot;

    private void Awake()
    {
        whiteScreenImage = whiteScreen.GetComponent<Image>();
        originWhiteScreenColor = whiteScreenImage.color;
        setup();
    }

    void Update()
    {
        cookFinishAndMove();
    }

    private void setup()
    {
        isCorrect = false;

        whiteScreenImage.color = originWhiteScreenColor;

        inputIngredientList.Clear();
        correctIngredientList.Clear();
        correctIngredientList.Add(IngredientType.Butter);
        correctIngredientList.Add(IngredientType.Milk);
        correctIngredientList.Add(IngredientType.Egg);
        correctIngredientList.Sort();
    }

    private void cookFinishAndMove()
    {
        // 요리 완성되었을 때 판정
        if (isCorrect)
        {
            // 좌클릭 눌렀을 때
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit = CastRay();
                GameObject newObj = Instantiate(completeIngredientPrefab, completeSlot);
                newObj.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                newObj.transform.SetAsFirstSibling();
                StartCoroutine(fadeOutWhiteScreen());
                setup();
                //Debug.Log(hit.point);
            }

        }
    }


    private IEnumerator fadeOutWhiteScreen()
    {
        Color startColor = whiteScreenImage.color;
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsed / fadeDuration);
            whiteScreenImage.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            yield return null;
        }
        whiteScreenImage.color = new Color(startColor.r, startColor.g, startColor.b, 0f);
        whiteScreen.SetActive(false);
        Debug.Log("요리 완성 페이드 아웃");
    }

    private RaycastHit CastRay()
    {
        Vector2 screenMousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldMousePos = Camera.main.ScreenToWorldPoint(screenMousePos);
        RaycastHit hit;
        Physics.Raycast(screenMousePos, worldMousePos, out hit);
        return hit;
    }

    public void OnClickFinish()
    {
        inputIngredientList.Sort();
        isCorrect = inputIngredientList.SequenceEqual(correctIngredientList);

        foreach (Transform child in cookingSlot.transform)
        {
            if (child.CompareTag("Ingredient"))
            {
                Debug.Log("Destroying " + child.name);
                child.gameObject.SetActive(false);
                //Destroy(child.gameObject);
            }
        }

        if (isCorrect)
        {
            // 완성된 재료 프리팹을 생성해서 completeSlot에 붙임
            GameObject newObj = Instantiate(correctCookedFoodPrefab, cookingSlot);
            newObj.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        }

        else
        {
            inputIngredientList.Clear();
            GameObject newObj = Instantiate(wrongCookedFoodPrefab, cookingSlot);
            newObj.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        }
    }


}
