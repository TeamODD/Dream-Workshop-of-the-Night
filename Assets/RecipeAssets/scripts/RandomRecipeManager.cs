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
    public MoveObjectUpDown moveScript; // ����� �̵� ��ũ��Ʈ

    // ���� ��� ����
    public Text fixedIngredientSlot1Text;
    public Text fixedIngredientSlot2Text;
    public Text fixedIngredientSlot3Text;
    // ���� ��� ����
    public Text randomIngredientSlot4Text;
    public Text randomIngredientSlot5Text;
    public Text randomIngredientSlot6Text;

    public string[] possibleImaginationIngredients = { "����", "����", "�ٳ���" }; // ����
    public int numRandomImagination = 4;
    public float displayDuration = 3f; // ������ ǥ�� �ð�

    private System.Action onRecipeHiddenCallback;
    private List<IngredientCount> currentFixedRecipe;
    private List<IngredientCount> currentRandomRecipe;

    void Awake()
    {
        if (moveScript == null)
        {
            moveScript = GetComponent<MoveObjectUpDown>();
        }
        randomRecipePanel.SetActive(false); // ���� �� ��Ȱ��ȭa
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
        // ���ϴ� ��ǥ Y ��ġ�� ���� (��: ȭ�� �߾� ���)
        float targetY = 0f; // �� ���� ĵ���� �ػ󵵿� ��Ŀ�� ���� ���� �ʿ�
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