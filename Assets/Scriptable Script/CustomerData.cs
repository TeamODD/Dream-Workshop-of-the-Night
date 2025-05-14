using UnityEngine;

[CreateAssetMenu(fileName = "CustomerData", menuName = "CookingGame/CustomerData")]
public class CustomerData : ScriptableObject
{
    public string customerName;
    public GameObject characterPrefab; // ���� �߰�
    public Order order;
}