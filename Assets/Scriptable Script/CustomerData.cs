using UnityEngine;

[CreateAssetMenu(fileName = "CustomerData", menuName = "CookingGame/CustomerData")]
public class CustomerData : ScriptableObject
{
    public string customerName;
    public GameObject characterPrefab; // 새로 추가
    public Order order;
}