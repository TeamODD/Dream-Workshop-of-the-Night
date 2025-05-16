using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CustomerDataControl : MonoBehaviour
{
    /// <summary>
    /// �մ� list
    /// 1�������� : A, B, C
    /// 2�������� : D, E, F
    /// 3�������� : G, H, I
    /// </summary>
    public List<CustomerData> customerData;
    /// <summary>
    /// �մ� ���� ��ȯ�� �� ����
    /// </summary>
    private bool customerSpriteChange;
    /// <summary>
    /// ���� ������ �޾ƿ� �մ��� �ε��� ó�� �ϱ� ���� ����
    /// </summary>

    private void Awake()
    {
        customerSpriteChange = false;
        customerData[0].customerSpriteChange = false;
    }


    public void changeCustomerSprite(/*bool isCustomerChange*/)
    {
        int index = CookingGameManager.Instance.getCookingCustomerIndex();
        customerSpriteChange = !customerSpriteChange;
        customerData[index].customerSpriteChange = customerSpriteChange;
        if (customerSpriteChange)
        {

        }
        else
        {

        }
    }

}