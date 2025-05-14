using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;
public class poroto_Game : MonoBehaviour
{
    public List<CustomerData> customers;
    public GameObject fixedIngredient;
    public GameObject randomIngredient;
    public GameObject gameStartScene;
    public GameObject customerclear;
    public Transform canvas;
    public Button fixedbutton;
    public Button startButton;
    public Button customerButton;

    private float fixedIngredient1;
    private float fixedIngredient2;
    private float fixedIngredient3;
    private int currentStage = 0;
    private int randomingredientCount = 0;

    void Start()
    {
        fixedIngredient.SetActive(false);
        randomIngredient.SetActive(false);
        customerclear.SetActive(false);

        startButton.interactable = true;
        customerButton.interactable = false;


        if (currentStage == 0)
        {
            startButton.onClick.AddListener(startOnClick);
        }
        else if (currentStage != 0)
        {
            startButton.onClick.AddListener(startOnClick2);
        }

        fixedbutton.onClick.AddListener(fixedbookOnClick);
        customerButton.onClick.AddListener(customerAnimation);

        if (currentStage == 1)
        {
            Debug.Log("Customer 1 is clear");
        }
        if (currentStage == 2)
        {
            Debug.Log("Customer 2 is clear");
        }
        if (currentStage == 3)
        {
            Debug.Log("Customer 3 is clear");
        }
    }

    void gameStart()
    {

    }
    void startOnClick()
    {
        fixedIngredient.SetActive(true);
        startButton.interactable = false;
        fixedbutton.interactable = true;
    }

    void startOnClick2()
    {
        startButton.interactable = false;
        GameObject go = Instantiate(customers[currentStage].characterPrefab);
        go.transform.SetParent(canvas, worldPositionStays: false);
    }

    void fixedbookOnClick()
    {
        fixedIngredient.SetActive(false);
        GameObject go = Instantiate(customers[currentStage].characterPrefab);
        go.transform.SetParent(canvas, worldPositionStays: false);
        customerclear.SetActive(true);
        customerButton.interactable = true;
    }

    void customerAnimation()
    {
        randomIngredient.SetActive(true);
        customerButton.interactable = false;
    }

    void randomrecipebook()
    {
        randomingredientCount = customers[currentStage].order.randomingredients.Count;
        GetRandomAmount(randomingredientCount);

    }

    void GetRandomAmount(int randomingredientCount)
    {
        for (int i = 0; i < randomingredientCount; i++)
        {
            int randomAmount = Random.Range(1, 4);
            Debug.Log("Random Amount: " + randomAmount);
        }
    }

}