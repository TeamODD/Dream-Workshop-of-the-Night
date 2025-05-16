using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

[System.Serializable]
public struct IngredientData
{
    public string ingredientName;
    public Sprite ingredientSprite;
}

[System.Serializable]
public struct IngredientCount
{
    public IngredientData ingredientData;
    public int count;
}

public class RandomRecipeManager : MonoBehaviour
{
    public GameObject randomRecipePanel;
    public MoveObjectUpDown moveScript; // 연결된 이동 스크립트

    // 고정 재료 슬롯
    public Image fixedIngredientSlot1Image;
    public Image fixedIngredientSlot2Image;
    public Image fixedIngredientSlot3Image;
    public Text fixedIngredientSlot1CountText;
    public Text fixedIngredientSlot2CountText;
    public Text fixedIngredientSlot3CountText;

    // 랜덤 재료 슬롯
    public Image randomIngredientSlot4Image;
    public Image randomIngredientSlot5Image;
    public Image randomIngredientSlot6Image;
    public Text randomIngredientSlot4CountText;
    public Text randomIngredientSlot5CountText;
    public Text randomIngredientSlot6CountText;

    public IngredientData[] possibleImaginationIngredients;
    public int numRandomImagination = 4;
    public float displayDuration = 3f;

    private System.Action onRecipeHiddenCallback;
    private List<IngredientCount> currentFixedRecipe;
    private List<IngredientCount> currentRandomRecipe;

    void Awake()
    {
        if (moveScript == null)
        {
            moveScript = GetComponent<MoveObjectUpDown>();
        }
        randomRecipePanel.SetActive(false);
    }

    public void SetFixedRecipe(List<IngredientCount> fixedRecipe)
    {
        currentFixedRecipe = fixedRecipe;
        UpdateFixedRecipeUI();
    }

    public void GenerateAndShowRandomRecipe(System.Action callback)
    {
        onRecipeHiddenCallback = callback;
        currentRandomRecipe = new List<IngredientCount>();
        randomRecipePanel.SetActive(true); // 패널 활성화

        for (int i = 0; i < numRandomImagination; i++)
        {
            if (possibleImaginationIngredients.Length > 0)
            {
                IngredientData randomIngredient = possibleImaginationIngredients[Random.Range(0, possibleImaginationIngredients.Length)];

                int index = currentRandomRecipe.FindIndex(item => item.ingredientData.ingredientName == randomIngredient.ingredientName);

                if (index != -1)
                {
                    if (currentRandomRecipe[index].count < 4)
                    {
                        currentRandomRecipe[index] = new IngredientCount
                        {
                            ingredientData = currentRandomRecipe[index].ingredientData,
                            count = currentRandomRecipe[index].count + 1
                        };
                    }
                }
                else
                {
                    currentRandomRecipe.Add(new IngredientCount { ingredientData = randomIngredient, count = 1 });
                }
            }
        }

        currentRandomRecipe = currentRandomRecipe.OrderBy(item => item.ingredientData.ingredientName).ToList();

        UpdateRandomRecipeUI(currentRandomRecipe);

        float targetY = 0f;
        moveScript.MoveUp(targetY, () => StartCoroutine(HideRecipeAfterDelay(displayDuration)));
    }

    void UpdateFixedRecipeUI()
    {
        Image[] fixedSlots = { fixedIngredientSlot1Image, fixedIngredientSlot2Image, fixedIngredientSlot3Image };
        Text[] fixedCountTexts = { fixedIngredientSlot1CountText, fixedIngredientSlot2CountText, fixedIngredientSlot3CountText };

        for (int i = 0; i < fixedSlots.Length; i++)
        {
            if (i < currentFixedRecipe.Count)
            {
                fixedSlots[i].sprite = currentFixedRecipe[i].ingredientData.ingredientSprite;
                fixedCountTexts[i].text = $"x{currentFixedRecipe[i].count}";
                fixedSlots[i].enabled = true;
                fixedCountTexts[i].enabled = true;
            }
            else
            {
                fixedSlots[i].sprite = null;
                fixedCountTexts[i].text = "";
                fixedSlots[i].enabled = false;
                fixedCountTexts[i].enabled = false;
            }
        }
    }

    void UpdateRandomRecipeUI(List<IngredientCount> randomIngredients)
    {
        Image[] randomSlots = { randomIngredientSlot4Image, randomIngredientSlot5Image, randomIngredientSlot6Image };
        Text[] randomCountTexts = { randomIngredientSlot4CountText, randomIngredientSlot5CountText, randomIngredientSlot6CountText };

        for (int i = 0; i < randomSlots.Length; i++)
        {
            if (i < randomIngredients.Count)
            {
                randomSlots[i].sprite = randomIngredients[i].ingredientData.ingredientSprite;
                randomCountTexts[i].text = $"x{randomIngredients[i].count}";
                randomSlots[i].enabled = true;
                randomCountTexts[i].enabled = true;
            }
            else
            {
                randomSlots[i].sprite = null;
                randomCountTexts[i].text = "";
                randomSlots[i].enabled = false;
                randomCountTexts[i].enabled = false;
            }
        }
    }

    IEnumerator HideRecipeAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        moveScript.MoveDown(onRecipeHiddenCallback);
    }
}
