using UnityEngine;
using UnityEngine.UI;
public class FadeIn : MonoBehaviour
{
    public Material fadeMaterial;
    public float duration = 3.0f;

    private float time = 0f;
    private bool faded = false;
    public GameObject fadeImage;
    public Sprite newImage;
    public GameObject startButton;
    public GameObject rulesButton;
    public GameObject gameOutButton;
    void Start()
    {
        fadeMaterial.SetFloat("_Fade", 0f);
        startButton.SetActive(false);
        rulesButton.SetActive(false);
        gameOutButton.SetActive(false);
    }

    void Update()
    {
        if (time < duration)
        {
            time += Time.deltaTime;
            float fade = Mathf.Lerp(0f, 1f, time / duration);
            fadeMaterial.SetFloat("_Fade", fade);
        }
        else if (!faded)
        {
            fadeImage.SetActive(false);
            faded = true;
            GameObject background = GameObject.Find("background");
            Image img = background.GetComponent<Image>();
            img.sprite = newImage;
            startButton.SetActive(true);
            rulesButton.SetActive(true);
            gameOutButton.SetActive(true);
        }
    }

}