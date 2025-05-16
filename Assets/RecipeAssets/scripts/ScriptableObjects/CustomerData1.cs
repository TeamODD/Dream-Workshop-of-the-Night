using UnityEngine;

[CreateAssetMenu(fileName = "CustomerData", menuName = "CookingGame/CustomerData")]
public class CustomerData1 : ScriptableObject
{
    public string customerName;
    public GameObject characterPrefab; // 새로 추가
    public Order1 order;
}