using UnityEngine;

public class AspectRatioController : MonoBehaviour
{
    private Camera mainCamera;
    private float targetAspect;
    
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        targetAspect = 16.0f / 9.0f; // 16:9 aspect ratio

        UpdateAspectRatio();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs((float)Screen.width / (float)Screen.height - targetAspect) > 0.01f)
        {
            UpdateAspectRatio();
        }
    }

    void UpdateAspectRatio()
    {
        float windowAspect = (float)Screen.width / (float)Screen.height;
        float scaleHeight = windowAspect / targetAspect;

        if (scaleHeight < 1.0f)
        {
            Rect rect = mainCamera.rect;

            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;

            mainCamera.rect = rect;
        }
        else
        {
            float scaleWidth = 1.0f / scaleHeight;

            Rect rect = mainCamera.rect;

            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;

            mainCamera.rect = rect;
        }
    }
}
