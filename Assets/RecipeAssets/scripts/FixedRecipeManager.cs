using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class FixedRecipeManager : MonoBehaviour
{
    public GameObject fixedRecipePanel;
    public List<Image> ingredientImages; // ������ ��� �̹������� ���� ����Ʈ
    public MoveObjectUpDown moveScript; // UI �г��� �������� �����ϴ� ��ũ��Ʈ

    private System.Action onFixedRecipeHiddenCallback; // ������ �г��� ������ �� ����� �ݹ� �Լ�

    void Awake()
    {
        if (moveScript == null) moveScript = GetComponent<MoveObjectUpDown>();
        fixedRecipePanel.SetActive(false); // ���� �� ������ �г��� ����ϴ�.
    }

    // ���� �����Ǹ� ǥ���ϴ� �Լ�
    public void ShowFixedRecipe(List<IngredientCount> recipe, System.Action callback)
    {
        fixedRecipePanel.SetActive(true); // ������ �г��� Ȱ��ȭ�մϴ�.

        // ���� ��� ��� �̹����� ����ϴ�.
        foreach (var image in ingredientImages)
        {
            image.gameObject.SetActive(false);
        }

        // �����ǿ� ���� �ʿ��� ��� �̹����� Ȱ��ȭ�ϰ� �����մϴ�.
        for (int i = 0; i < recipe.Count; i++)
        {
            if (i < ingredientImages.Count)
            {
                // Resources ������ Sprites �������� ��� �̸��� �ش��ϴ� �̹����� �ε��մϴ�.
                string imagePath = "Sprites/" + recipe[i].ingredientName + ".png";
                ingredientImages[i].sprite = Resources.Load<Sprite>(imagePath);

                // �̹����� ����� �ε�Ǿ����� Ȱ��ȭ�մϴ�.
                if (ingredientImages[i].sprite != null)
                {
                    ingredientImages[i].gameObject.SetActive(true);
                }
                else
                {
                    Debug.LogError(recipe[i].ingredientName + " �׸� ������ ã�� �� �����ϴ�: " + imagePath);
                }
            }
            else
            {
                Debug.LogWarning("ǥ���� ��ᰡ �� ������, ingredientImages ����Ʈ�� ������ �����մϴ�.");
                break; // �� �̻� ó���� ��ᰡ �����Ƿ� ������ �����մϴ�.
            }
        }

        // �г��� ȭ�鿡 ǥ���ϴ� �ִϸ��̼��� �����ϰ�, �ִϸ��̼� �Ϸ� �� �ݹ� �Լ��� �����մϴ�.
        moveScript.MoveUp(0f, callback);
        onFixedRecipeHiddenCallback = HideFixedRecipe; // ���� �ݹ� �Լ��� �����մϴ�.
    }

    // ������ �г��� ����� �Լ�
    public void HideFixedRecipe()
    {
        // �г��� ȭ�� �Ʒ��� ����� �ִϸ��̼��� �����ϰ�, �ִϸ��̼� �Ϸ� �� �ݹ� �Լ��� �����մϴ�.
        moveScript.MoveDown(onFixedRecipeHiddenCallback);
    }
}