using UnityEngine;
using UnityEngine.UI;

// made with the help of github copilot
public class Crosshair : MonoBehaviour
{
    public Image crosshairImage; // Reference to the crosshair image
    public Camera fpsCamera; // Reference to the FPS camera

    void Start()
    {
        // Ensure the crosshair is centered
        if (crosshairImage != null)
        {
            RectTransform rectTransform = crosshairImage.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = Vector2.zero;
        }
    }

    void Update()
    {
        // Optionally, you can add code here to update the crosshair based on game state
    }
}