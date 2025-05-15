using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "CustomerData", menuName = "CookingGame/CustomerData")]
public class CustomerData : ScriptableObject
{
    public string customerName;
    public List<GameObject> characterPrefab; // 새로 추가
    public int characterPrefabIndex;
    public Order order;
}