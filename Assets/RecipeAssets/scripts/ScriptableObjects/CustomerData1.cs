using UnityEngine;

[CreateAssetMenu(fileName = "CustomerData", menuName = "CookingGame/CustomerData")]
public class CustomerData1 : ScriptableObject
{
    public string customerName;
    public GameObject characterPrefab; // ���� �߰�
    public Order1 order;
}