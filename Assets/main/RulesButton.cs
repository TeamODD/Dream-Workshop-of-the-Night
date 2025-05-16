using UnityEngine;
using System.Collections;
public class RulesButton : MonoBehaviour
{
    public GameObject RulesPanel;

    void Start()
    {
        RulesPanel.SetActive(false);
    }

    public void selectRules()
    {
        RulesPanel.SetActive (true);
    }
    public void selectExit()
    {
        RulesPanel.SetActive (false);
    }
}
