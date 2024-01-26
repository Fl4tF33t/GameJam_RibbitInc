using UnityEngine;

public class RotateAroundPivot : MonoBehaviour
{
    public GameObject pivotPoint; // Assign the pivot point GameObject in the Unity Editor
    public float rotationSpeed = 3f; // Adjust this value to change the rotation speed

    void Update()
    {
        if (pivotPoint != null)
        {
            if (Input.GetKey(KeyCode.A))
            {
                Debug.Log("Testing left");
                transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                Debug.Log("Testing right");
                transform.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
            }
        }
        else
        {
            Debug.LogError("Pivot point GameObject is not assigned!");
        }
    }
}

