using UnityEngine;
using UnityEngine.UI;

public class MoveManager : MonoBehaviour
{
    public Button you;
    public GameObject we;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        we.SetActive(true);
        you.onClick.AddListener(MoveUp);

    }
    // Update is called once per frame

    void MoveUp()
    {
        we.transform.position = new Vector3(
            we.transform.position.x,
            transform.position.y + 20f,
            we.transform.position.z
        );
    }
}