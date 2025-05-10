using UnityEngine;
using UnityEngine.UI;

public class CookingGameManager : MonoBehaviour
{
    private static CookingGameManager instance = null;
    public static CookingGameManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public Image progressImage;
    public float duration = 5f; // 몇 초 동안 감소할지
    private float timer;

    void Start()
    {
        timer = duration;
    }

    void Update()
    {
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
            float fillAmount = Mathf.Clamp01(timer / duration);
            progressImage.fillAmount = fillAmount;
        }
    }

}
