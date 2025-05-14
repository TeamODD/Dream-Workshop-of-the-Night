using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // �̱��� �ν��Ͻ�

    public FixedRecipeManager fixedRecipeManager; // ���� ������ ���� ��ũ��Ʈ
    public CustomerCharacter customerCharacter; // �մ� ĳ���� ���� ��ũ��Ʈ
    public CustomerDialogue customerDialogue; // �մ� ��ȭâ ���� ��ũ��Ʈ
    public RandomRecipeManager randomRecipeManager; // ���� ������ ���� ��ũ��Ʈ
    public CustomerReactionUI customerReactionUI; // �մ� ���� UI ���� ��ũ��Ʈ

    public int currentStage = 1; // ���� �������� ��ȣ
    public int customersPerStage = 3; // �� ���������� �մ� ��
    private int currentCustomerCount = 0; // ���� ������������ ó���� �մ� ��

    [System.Serializable]
    public class StageRecipe
    {
        public List<IngredientCount> fixedIngredients; // ���� ������ ��� ���
        public string[] possibleImaginationIngredients; // ��� ������ ������ ��� �迭
        public int numRandomImagination; // ��� ������ ��� ����
        public string customerDialogue; // �մ� ���
        public Sprite customerSprite; // �մ� ��������Ʈ
    }
    public StageRecipe[] stageRecipes; // ���������� ������ �� �մ� ���� �迭

    void Awake()
    {
        // �̱��� ���� ����: ���� �Ŵ��� �ν��Ͻ��� �ϳ��� �����ϵ��� ��
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); } else { Destroy(gameObject); }
    }

    void Start()
    {
        // �� UI �� ĳ���� �̵� ��ũ��Ʈ�� �ʱ� ��ġ ����
        fixedRecipeManager.moveScript.InitializePositions(0f, -500f);
        customerCharacter.moveScript.InitializePositions(0f, -500f);
        randomRecipeManager.moveScript.InitializePositions(0f, -500f);
        customerReactionUI.moveScript.InitializePositions(0f, -500f);
        StartStage(); // ù ��° �������� ����
    }

    void StartStage()
    {
        // ��� ���������� �Ϸ������� ����
        if (currentStage > stageRecipes.Length) { Debug.Log("��� �������� Ŭ����!"); return; }
        currentCustomerCount = 0; // ���� �������� �մ� �� �ʱ�ȭ
        Debug.Log($"�������� {currentStage} ����!");
        StartCustomerFlow(); // �մ� ���� �帧 ����
    }

    void StartCustomerFlow()
    {
        // ���� ���������� ��� �մ��� ���������� ���� �������� ����
        if (currentCustomerCount >= customersPerStage) { Debug.Log($"�������� {currentStage} Ŭ����!"); currentStage++; StartStage(); return; }
        Debug.Log($"�մ� " + (currentCustomerCount + 1) + " ���� �غ�");
        // ���� ������ UI�� �����ְ�, ���� �Ϸ� �� OnFixedRecipeHidden ȣ��
        fixedRecipeManager.ShowFixedRecipe(stageRecipes[currentStage - 1].fixedIngredients, OnFixedRecipeHidden);
    }

    // ���� ������ UI�� ������ �� ȣ��Ǵ� �Լ�
    public void OnFixedRecipeHidden()
    {
        // �մ� ��������Ʈ ���� �� ���� �ִϸ��̼� ����, �Ϸ� �� �ݹ����� �մ� ��� ǥ��
        customerCharacter.SetSprite(stageRecipes[currentStage - 1].customerSprite);
        customerCharacter.Enter(() => { // �մ� ���� �ִϸ��̼� �Ϸ� �� �ݹ� ����
            customerDialogue.ShowDialogue(stageRecipes[currentStage - 1].customerDialogue, OnCustomerDialogueHidden);
        });
    }

    // �մ� ��ȭâ�� ���� �� ȣ��Ǵ� �Լ�
    public void OnCustomerDialogueHidden()
    {
        // ���� ������ ���� �� UI ǥ��, ���� �Ϸ� �� OnRandomRecipeHidden ȣ��
        randomRecipeManager.SetFixedRecipe(stageRecipes[currentStage - 1].fixedIngredients);
        randomRecipeManager.possibleImaginationIngredients = stageRecipes[currentStage - 1].possibleImaginationIngredients;
        randomRecipeManager.numRandomImagination = stageRecipes[currentStage - 1].numRandomImagination;
        randomRecipeManager.GenerateAndShowRandomRecipe(OnRandomRecipeHidden);
    }

    // ���� ������ UI�� ������ �� ȣ��Ǵ� �Լ�
    public void OnRandomRecipeHidden()
    {
        Debug.Log("������ Ȯ�� �Ϸ�. �� 2�� �̵��մϴ�.");
        SceneManager.LoadScene("Scene2"); // �丮 ������ �̵�
    }

    // �丮 ������ �丮 �Ϸ� �� ȣ��Ǵ� �Լ� (����/���� ���� ����)
    public void OnCookingCompleted(bool success)
    {
        Debug.Log("�丮 ���: " + (success ? "����" : "����"));
        // �մ� ���� UI ǥ�� �� �մ� ���� ó��
        customerReactionUI.ShowResult(success, () => {
            // �ӽ� ����/���� ǥ�� (���ϴ� �ǵ�� �������� ����)
            if (success) customerCharacter.GetComponent<UnityEngine.UI.Image>().color = Color.green;
            else customerCharacter.GetComponent<UnityEngine.UI.Image>().color = Color.red;
            customerCharacter.Exit(() => {
                currentCustomerCount++; // ���� �������� �մ� �� ����
                StartCustomerFlow(); // ���� �մ� �Ǵ� �������� ����
            });
        });
    }
}