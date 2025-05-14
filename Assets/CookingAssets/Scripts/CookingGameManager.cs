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
    public float duration = 40f; // �� ���� ���� �� �ɸ��� �ð� (��)
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

            // Z������ ȸ�� (2D �ð�ٴ� ����)
            progressImage.rectTransform.localEulerAngles = new Vector3(0f, 0f, -(-18f+angle));
        }
    }

}
