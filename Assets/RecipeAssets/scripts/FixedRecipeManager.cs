using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class FixedRecipeManager : MonoBehaviour
{
    public GameObject fixedRecipePanel;
    public List<Image> ingredientImages; // 레시피 재료 이미지들을 담을 리스트
    public MoveObjectUpDown moveScript; // UI 패널의 움직임을 제어하는 스크립트

    private System.Action onFixedRecipeHiddenCallback; // 레시피 패널이 숨겨진 후 실행될 콜백 함수

    void Awake()
    {
        if (moveScript == null) moveScript = GetComponent<MoveObjectUpDown>();
        fixedRecipePanel.SetActive(false); // 시작 시 레시피 패널을 숨깁니다.
    }

    // 고정 레시피를 표시하는 함수
    public void ShowFixedRecipe(List<IngredientCount> recipe, System.Action callback)
    {
        fixedRecipePanel.SetActive(true); // 레시피 패널을 활성화합니다.

        // 먼저 모든 재료 이미지를 숨깁니다.
        foreach (var image in ingredientImages)
        {
            image.gameObject.SetActive(false);
        }

        // 레시피에 따라 필요한 재료 이미지를 활성화하고 설정합니다.
        for (int i = 0; i < recipe.Count; i++)
        {
            if (i < ingredientImages.Count)
            {
                // Resources 폴더의 Sprites 폴더에서 재료 이름에 해당하는 이미지를 로드합니다.
                string imagePath = "Sprites/" + recipe[i].ingredientName + ".png";
                ingredientImages[i].sprite = Resources.Load<Sprite>(imagePath);

                // 이미지가 제대로 로드되었으면 활성화합니다.
                if (ingredientImages[i].sprite != null)
                {
                    ingredientImages[i].gameObject.SetActive(true);
                }
                else
                {
                    Debug.LogError(recipe[i].ingredientName + " 그림 파일을 찾을 수 없습니다: " + imagePath);
                }
            }
            else
            {
                Debug.LogWarning("표시할 재료가 더 있지만, ingredientImages 리스트에 공간이 부족합니다.");
                break; // 더 이상 처리할 재료가 없으므로 루프를 종료합니다.
            }
        }

        // 패널을 화면에 표시하는 애니메이션을 시작하고, 애니메이션 완료 후 콜백 함수를 실행합니다.
        moveScript.MoveUp(0f, callback);
        onFixedRecipeHiddenCallback = HideFixedRecipe; // 숨김 콜백 함수를 설정합니다.
    }

    // 레시피 패널을 숨기는 함수
    public void HideFixedRecipe()
    {
        // 패널을 화면 아래로 숨기는 애니메이션을 시작하고, 애니메이션 완료 후 콜백 함수를 실행합니다.
        moveScript.MoveDown(onFixedRecipeHiddenCallback);
    }
}