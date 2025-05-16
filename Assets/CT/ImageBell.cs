using UnityEngine;
using UnityEngine.UI;

public class ImageBell : MonoBehaviour
{
    public Sprite bell;
    public Sprite bellPush;

    private Button btn;
    private Image image;
    private void Awake()
    {
        btn = GetComponent<Button>();
        image = GetComponent<Image>();
        image.sprite = bell;
    }
    public void OnBellPush()
    {
        image.sprite = bellPush;
    }
}
