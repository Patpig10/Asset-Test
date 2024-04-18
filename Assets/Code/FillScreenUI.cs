using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillScreenUI : MonoBehaviour
{
    public Image backgroundImage; // Reference to your UI image component

    void Start()
    {
        // Ensure we have the reference to the background image
        if (backgroundImage == null)
        {
            Debug.LogError("Background Image is not assigned!");
            return;
        }

        // Get the RectTransform component of the Canvas
        RectTransform canvasRect = GetComponent<RectTransform>();

        // Get the screen dimensions
        float screenWidth = canvasRect.rect.width;
        float screenHeight = canvasRect.rect.height;

        // Get the RectTransform component of the image
        RectTransform bgRectTransform = backgroundImage.rectTransform;

        // Set the size of the image to fill the canvas
        bgRectTransform.sizeDelta = new Vector2(screenWidth, screenHeight);
        bgRectTransform.anchoredPosition = Vector2.zero; // Position at the center of the canvas
    }
}
