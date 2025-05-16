using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// �»�ܿ� �ִ� Ÿ�̸� �ð� �����ϴ� ��ũ��Ʈ
/// </summary>
public class Timer : MonoBehaviour
{
    public Image progressImage;
    public float duration = 60f; // �� ���� ���� �� �ɸ��� �ð� (��)
    private float elapsed = 0f;

    void Update()
    {
        if (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            float angle = (elapsed / duration) * 360f;

            // Z������ ȸ�� (2D �ð�ٴ� ����)
            progressImage.rectTransform.localEulerAngles = new Vector3(0f, 0f, 18f - angle);
        }
        else
        {
            // Ÿ�� �ƿ� �� gameOver ������ ����
            SceneManager.LoadScene("gameOver");
        }
    }
}
