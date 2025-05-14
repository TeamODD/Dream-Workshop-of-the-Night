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
    public float duration = 40f; // 한 바퀴 도는 데 걸리는 시간 (초)
    private float elapsed = 0f;

    void Start()
    {
        //timer = duration;
    }

    void Update()
    {
        if (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            float angle = (elapsed/ duration) * 360f;

            // Z축으로 회전 (2D 시계바늘 기준)
            progressImage.rectTransform.localEulerAngles = new Vector3(0f, 0f, -(-18f+angle));
        }
    }

}
