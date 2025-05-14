using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // 싱글톤 인스턴스

    public FixedRecipeManager fixedRecipeManager; // 고정 레시피 관리 스크립트
    public CustomerCharacter customerCharacter; // 손님 캐릭터 제어 스크립트
    public CustomerDialogue customerDialogue; // 손님 대화창 제어 스크립트
    public RandomRecipeManager randomRecipeManager; // 랜덤 레시피 관리 스크립트
    public CustomerReactionUI customerReactionUI; // 손님 반응 UI 제어 스크립트

    public int currentStage = 1; // 현재 스테이지 번호
    public int customersPerStage = 3; // 각 스테이지당 손님 수
    private int currentCustomerCount = 0; // 현재 스테이지에서 처리한 손님 수

    [System.Serializable]
    public class StageRecipe
    {
        public List<IngredientCount> fixedIngredients; // 고정 레시피 재료 목록
        public string[] possibleImaginationIngredients; // 상상 레시피 가능한 재료 배열
        public int numRandomImagination; // 상상 레시피 재료 개수
        public string customerDialogue; // 손님 대사
        public Sprite customerSprite; // 손님 스프라이트
    }
    public StageRecipe[] stageRecipes; // 스테이지별 레시피 및 손님 정보 배열

    void Awake()
    {
        // 싱글톤 패턴 구현: 게임 매니저 인스턴스가 하나만 존재하도록 함
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); } else { Destroy(gameObject); }
    }

    void Start()
    {
        // 각 UI 및 캐릭터 이동 스크립트의 초기 위치 설정
        fixedRecipeManager.moveScript.InitializePositions(0f, -500f);
        customerCharacter.moveScript.InitializePositions(0f, -500f);
        randomRecipeManager.moveScript.InitializePositions(0f, -500f);
        customerReactionUI.moveScript.InitializePositions(0f, -500f);
        StartStage(); // 첫 번째 스테이지 시작
    }

    void StartStage()
    {
        // 모든 스테이지를 완료했으면 종료
        if (currentStage > stageRecipes.Length) { Debug.Log("모든 스테이지 클리어!"); return; }
        currentCustomerCount = 0; // 현재 스테이지 손님 수 초기화
        Debug.Log($"스테이지 {currentStage} 시작!");
        StartCustomerFlow(); // 손님 접대 흐름 시작
    }

    void StartCustomerFlow()
    {
        // 현재 스테이지의 모든 손님을 접대했으면 다음 스테이지 시작
        if (currentCustomerCount >= customersPerStage) { Debug.Log($"스테이지 {currentStage} 클리어!"); currentStage++; StartStage(); return; }
        Debug.Log($"손님 " + (currentCustomerCount + 1) + " 등장 준비");
        // 고정 레시피 UI를 보여주고, 숨김 완료 시 OnFixedRecipeHidden 호출
        fixedRecipeManager.ShowFixedRecipe(stageRecipes[currentStage - 1].fixedIngredients, OnFixedRecipeHidden);
    }

    // 고정 레시피 UI가 숨겨진 후 호출되는 함수
    public void OnFixedRecipeHidden()
    {
        // 손님 스프라이트 설정 및 등장 애니메이션 시작, 완료 시 콜백으로 손님 대사 표시
        customerCharacter.SetSprite(stageRecipes[currentStage - 1].customerSprite);
        customerCharacter.Enter(() => { // 손님 등장 애니메이션 완료 후 콜백 실행
            customerDialogue.ShowDialogue(stageRecipes[currentStage - 1].customerDialogue, OnCustomerDialogueHidden);
        });
    }

    // 손님 대화창이 닫힌 후 호출되는 함수
    public void OnCustomerDialogueHidden()
    {
        // 랜덤 레시피 생성 및 UI 표시, 숨김 완료 시 OnRandomRecipeHidden 호출
        randomRecipeManager.SetFixedRecipe(stageRecipes[currentStage - 1].fixedIngredients);
        randomRecipeManager.possibleImaginationIngredients = stageRecipes[currentStage - 1].possibleImaginationIngredients;
        randomRecipeManager.numRandomImagination = stageRecipes[currentStage - 1].numRandomImagination;
        randomRecipeManager.GenerateAndShowRandomRecipe(OnRandomRecipeHidden);
    }

    // 랜덤 레시피 UI가 숨겨진 후 호출되는 함수
    public void OnRandomRecipeHidden()
    {
        Debug.Log("레시피 확인 완료. 씬 2로 이동합니다.");
        SceneManager.LoadScene("Scene2"); // 요리 씬으로 이동
    }

    // 요리 씬에서 요리 완료 후 호출되는 함수 (성공/실패 여부 전달)
    public void OnCookingCompleted(bool success)
    {
        Debug.Log("요리 결과: " + (success ? "성공" : "실패"));
        // 손님 반응 UI 표시 후 손님 퇴장 처리
        customerReactionUI.ShowResult(success, () => {
            // 임시 성공/실패 표시 (원하는 피드백 로직으로 변경)
            if (success) customerCharacter.GetComponent<UnityEngine.UI.Image>().color = Color.green;
            else customerCharacter.GetComponent<UnityEngine.UI.Image>().color = Color.red;
            customerCharacter.Exit(() => {
                currentCustomerCount++; // 현재 스테이지 손님 수 증가
                StartCustomerFlow(); // 다음 손님 또는 스테이지 진행
            });
        });
    }
}