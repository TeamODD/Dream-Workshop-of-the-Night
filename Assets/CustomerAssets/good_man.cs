using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Data;

public class good_man : MonoBehaviour
{
    public List<CustomerData> customers;
    public GameObject startObject;
    public GameObject fixedIngredient;
    public GameObject randomIngredient;
    public GameObject customerPannel;
    public GameObject textBox;
    public Transform position;
    public Transform Parents;

    public Button startButton;
    public Button fixedOutgredient;
    public Button randomOutgredient;
    public Button customer;
    public Button text;

    private int currentStage = 0;
    void Start()
    {
        fixedIngredient.SetActive(false);
        randomIngredient.SetActive(false);
        customerPannel.SetActive(false);
        textBox.SetActive(false);
        startObject.SetActive(true);

        customer.interactable = false;

        startButton.onClick.AddListener(Active_Start);
        fixedOutgredient.onClick.AddListener(Active_fixed);
        customer.onClick.AddListener(Active_Customer);
        text.onClick.AddListener(Active_dialouge);
    }

    void Active_Start()
    {
        fixedIngredient.SetActive(true);
        startButton.interactable = false;
    }

    void Active_fixed()
    {
        fixedIngredient.SetActive(false);
        customerPannel.SetActive(true);
        CreateCustomer();
        customer.interactable = true;
    }

    void Active_Customer()
    {
        textBox.SetActive(true);
        customer.interactable = false;
    }

    void Active_dialouge()
    {
        textBox.SetActive(false);
        randomIngredient.SetActive(true);
        //3초정도 기다림 후 시행
        SceneManager.LoadScene("Cooking Scene");
    }

    void CreateCustomer()
    {
        GameObject go = Instantiate(customers[currentStage].characterPrefab[0]);
        go.transform.SetParent(Parents, worldPositionStays: false);
    }


}