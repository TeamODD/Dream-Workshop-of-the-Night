using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "CustomerData", menuName = "CookingGame/CustomerData")]
public class CustomerData : ScriptableObject
{
    public string customerName;
    public List<GameObject> characterPrefab; // ���� �߰�
    public bool customerSpriteChange;
    public Order order;
}