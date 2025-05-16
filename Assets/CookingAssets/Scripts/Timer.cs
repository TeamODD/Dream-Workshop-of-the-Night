using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// 좌상단에 있는 타이머 시간 관리하는 스크립트
/// </summary>
public class Timer : MonoBehaviour
{
    public Image progressImage;
    public float duration = 60f; // 한 바퀴 도는 데 걸리는 시간 (초)
    private float elapsed = 0f;

    void Update()
    {
        if (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            float angle = (elapsed / duration) * 360f;

            // Z축으로 회전 (2D 시계바늘 기준)
            progressImage.rectTransform.localEulerAngles = new Vector3(0f, 0f, 18f - angle);
        }
        else
        {
            // 타임 아웃 시 gameOver 씬으로 변경
            SceneManager.LoadScene("gameOver");
        }
    }
}
