using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CustomerDataControl : MonoBehaviour
{
    /// <summary>
    /// 손님 list
    /// 1스테이지 : A, B, C
    /// 2스테이지 : D, E, F
    /// 3스테이지 : G, H, I
    /// </summary>
    public List<CustomerData> customerData;
    /// <summary>
    /// 손님 외형 전환용 논리 변수
    /// </summary>
    private bool customerSpriteChange;

    private void Start()
    {
        customerSpriteChange = false;
        customerData[CookingGameManager.Instance.getCookingCustomerIndex()].customerSpriteChange = false;
    }


    public void changeCustomerSprite(/*bool isCustomerChange*/)
    {
        int index = CookingGameManager.Instance.getCookingCustomerIndex();
        customerSpriteChange = !customerSpriteChange;
        Debug.Log(index);
        customerData[index].customerSpriteChange = customerSpriteChange;
        if (customerSpriteChange)
        {

        }
        else
        {

        }
    }

}