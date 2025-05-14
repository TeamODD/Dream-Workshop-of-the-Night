using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using UnityEngine.SceneManagement;

[System.Serializable]
public struct IngredientCount
{
    public string ingredientName;
    public int count;
}

public class RandomRecipeManager : MonoBehaviour
{
    public GameObject randomRecipePanel;
    public MoveObjectUpDown moveScript; // 연결된 이동 스크립트

    // 고정 재료 슬롯
    public Text fixedIngredientSlot1Text;
    public Text fixedIngredientSlot2Text;
    public Text fixedIngredientSlot3Text;
    // 랜덤 재료 슬롯
    public Text randomIngredientSlot4Text;
    public Text randomIngredientSlot5Text;
    public Text randomIngredientSlot6Text;

    public string[] possibleImaginationIngredients = { "딸기", "초코", "바나나" }; // 예시
    public int numRandomImagination = 4;
    public float displayDuration = 3f; // 레시피 표시 시간

    private System.Action onRecipeHiddenCallback;
    private List<IngredientCount> currentFixedRecipe;
    private List<IngredientCount> currentRandomRecipe;

    void Awake()
    {
        if (moveScript == null)
        {
            moveScript = GetComponent<MoveObjectUpDown>();
        }
        randomRecipePanel.SetActive(false); // 시작 시 비활성화a
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

        for (int i = 0; i < numRandomImagination; i++)
        {
            if (possibleImaginationIngredients.Length > 0)
            {
                string randomIngredient = possibleImaginationIngredients[Random.Range(0, possibleImaginationIngredients.Length)];
                IngredientCount existing = currentRandomRecipe.FirstOrDefault(item => item.ingredientName == randomIngredient);
                if (existing.ingredientName != null && existing.count < 4)
                {
                    int index = currentRandomRecipe.IndexOf(existing);
                    currentRandomRecipe[index] = new IngredientCount { ingredientName = existing.ingredientName, count = existing.count + 1 };
                }
                else if (existing.ingredientName == null)
                {
                    currentRandomRecipe.Add(new IngredientCount { ingredientName = randomIngredient, count = 1 });
                }
            }
        }
        currentRandomRecipe = currentRandomRecipe.OrderBy(item => item.ingredientName).ToList();

        UpdateRandomRecipeUI(currentRandomRecipe);
        // 원하는 목표 Y 위치로 설정 (예: 화면 중앙 상단)
        float targetY = 0f; // 이 값은 캔버스 해상도와 앵커에 따라 조정 필요
        moveScript.MoveUp(targetY, () => StartCoroutine(HideRecipeAfterDelay(displayDuration)));
    }

    void UpdateFixedRecipeUI()
    {
        Text[] fixedSlots = { fixedIngredientSlot1Text, fixedIngredientSlot2Text, fixedIngredientSlot3Text };
        for (int i = 0; i < fixedSlots.Length; i++)
        {
            if (i < currentFixedRecipe.Count)
            {
                fixedSlots[i].text = $"{currentFixedRecipe[i].ingredientName} x{currentFixedRecipe[i].count}";
            }
            else
            {
                fixedSlots[i].text = "";
            }
        }
    }

    void UpdateRandomRecipeUI(List<IngredientCount> randomIngredients)
    {
        Text[] randomSlots = { randomIngredientSlot4Text, randomIngredientSlot5Text, randomIngredientSlot6Text };
        for (int i = 0; i < randomSlots.Length; i++)
        {
            if (i < randomIngredients.Count)
            {
                randomSlots[i].text = $"{randomIngredients[i].ingredientName} x{randomIngredients[i].count}";
            }
            else
            {
                randomSlots[i].text = "";
            }
        }
    }

    IEnumerator HideRecipeAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        moveScript.MoveDown(onRecipeHiddenCallback);
    }
}