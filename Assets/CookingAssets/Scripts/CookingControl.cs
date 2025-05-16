using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.EventSystems;

/// <summary>
/// 마법봉 버튼에 넣는 스크립트
/// 항아리에 들어온 재료와 정답 목록 비교
/// </summary>
public class CookingControl : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private RectTransform rect;
    private bool isSuccess;
    private bool isFull;

    public Animator animator;
    private void Awake()
    {
        isSuccess = false;
        isFull = false;
        rect = GetComponent<RectTransform>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        rect.localScale = new Vector3(1.2f, 1.2f, 1.0f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        rect.localScale = Vector3.one;
    }

    public void playCookingAnimation()
    {
        Debug.Log("성공 여부" + isSuccess+", isFull : "+isFull);
        if (isFull)
        {
            if (isSuccess)
            {
                animator.SetTrigger("Correct");
            }
            else
            {
                animator.SetTrigger("Fail");
            }
        }
    }

    public void playFullAnimation()
    {
        animator.Play("Cooking Full");
    }

    public void playEmptyAnimation()
    {
        animator.Play("Cooking Empty");
    }

    public void setFullEmpty(bool full)
    {
        isFull = full;
    }

    public void setSuccess(bool success)
    {
        isSuccess = success;
    }

}
