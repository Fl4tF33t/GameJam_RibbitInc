using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    private Camera mainCamera;
    private Vector2 screenBounds;

    void Start()
    {
        mainCamera = Camera.main;
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
    }

    void Update()
    {
        // Check if the character has moved out of the screen bounds
        if (transform.position.x > screenBounds.x)
        {
            transform.position = new Vector3(-screenBounds.x, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -screenBounds.x)
        {
            transform.position = new Vector3(screenBounds.x, transform.position.y, transform.position.z);
        }

/*        if (transform.position.y > screenBounds.y)
        {
            transform.position = new Vector3(transform.position.x, -screenBounds.y, transform.position.z);
        }
        else if (transform.position.y < -screenBounds.y)
        {
            transform.position = new Vector3(transform.position.x, screenBounds.y, transform.position.z);
        }*/
    }
}
