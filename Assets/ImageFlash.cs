using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ImageFlash : MonoBehaviour
{
    public Image image; // Reference to the SpriteRenderer component of the image
    public float flashSpeed = 1.0f; // Speed at which the transparency changes
    public float flashDelay = 1.0f; // Delay between each flash

    private void Start()
    {
        image = GetComponent<Image>();
        StartCoroutine(FlashRoutine());
    }

    void OnEnable()
    {
        StartCoroutine(FlashRoutine());
    }
    IEnumerator FlashRoutine()
    {
        while (true)
        {
            // Fade out (decrease transparency)
            while (image.color.a > 0)
            {
                Color newColor = image.color;
                newColor.a -= Time.deltaTime * flashSpeed;
                image.color = newColor;
                yield return null;
            }

            yield return new WaitForSeconds(flashDelay);

            // Reset transparency to full
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1.0f);

            yield return null;
        }
    }
}
