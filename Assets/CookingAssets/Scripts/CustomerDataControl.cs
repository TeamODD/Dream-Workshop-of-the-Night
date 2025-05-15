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
    /// <summary>
    /// 현재 정보를 받아온 손님의 인덱스 처리 하기 위한 변수
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