using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HintControl : MonoBehaviour
{
    public GameObject hintPanel;
    public Button hintButton;
    private bool activated;

    private void Awake()
    {
        activated = false;
        hintButton.interactable = true;
    }

    public void OnClick()
    {
        hintButton.interactable = false;
        hintPanel.SetActive(true);
        StartCoroutine(openHint());
    }

    private IEnumerator openHint()
    {
        yield return new WaitForSeconds(5.0f);
        hintPanel.SetActive(false);
    }
}
