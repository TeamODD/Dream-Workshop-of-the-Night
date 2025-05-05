using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public float zoomSpeed = 5f;
    public float delayBeforeSceneChange = 0.15f;
    private bool isZooming = false;
    private Camera mainCamera;
    private float targetSize;
    private Vector3 targetPosition;
    private float timer = 0f;
    private void Start()
    {
        mainCamera = Camera.main;
    }
    private void Update()
    {
        if (isZooming)
        {
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, targetSize, zoomSpeed * Time.deltaTime);
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, targetPosition, zoomSpeed * Time.deltaTime);
            if (Mathf.Abs(mainCamera.orthographicSize - targetSize) < 0.01f)
            {
                timer += Time.deltaTime;
                if (timer > delayBeforeSceneChange)
                {
                    SceneManager.LoadScene(1);
                }
            }
        }
    }

    public void SelectStart()
    {
        isZooming = true;
        Vector3 worldButtonPos = transform.position;
        targetPosition = new Vector3(worldButtonPos.x, worldButtonPos.y, mainCamera.transform.position.z);
        float buttonHeight = GetComponent<RectTransform>().rect.height * transform.lossyScale.y;
        targetSize = buttonHeight * 0.12f;
    }
}
