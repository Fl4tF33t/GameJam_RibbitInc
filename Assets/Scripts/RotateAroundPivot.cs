using System;
using System.Collections;
using UnityEngine;

public class RotateAroundPivot : MonoBehaviour
{
    public GameObject pivotPoint; // Assign the pivot point GameObject in the Unity Editor
    public float rotationSpeed = 3f; // Adjust this value to change the rotation speed
    public float maxRotationAngle = 45f; // Adjust this value to change the maximum rotation angle

    public bool sweepShoot = false;
    public bool rotateClockwise = true;
    public float sweepSpeed = 2f;

    void Update()
    {
        if (!sweepShoot)
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
    }

    void LateUpdate()
    {
        // Clamp rotation angles
        Vector3 eulerAngles = transform.localEulerAngles;

        // Convert angle to the range of -180 to 180 degrees
        float clampedZRotation = (eulerAngles.z > 180f) ? eulerAngles.z - 360f : eulerAngles.z;

        // Clamp the angle within the desired range
        float clampedAngle = Mathf.Clamp(clampedZRotation, -maxRotationAngle, maxRotationAngle);

        // Convert the clamped angle back to the range of 0 to 360 degrees
        float clampedEulerZ = (clampedAngle < 0f) ? clampedAngle + 360f : clampedAngle;

        eulerAngles.z = clampedEulerZ;
        transform.localEulerAngles = eulerAngles;

        if(sweepShoot)
        {
            if (clampedAngle == -maxRotationAngle)
            {
                rotateClockwise = false;
            }
            else if (clampedAngle == maxRotationAngle)
            {
                rotateClockwise = true;
            }
        }
    }

    public void SweepShoot()
    {
        sweepShoot = true;
        StartCoroutine(SweepShootCoroutine());
    }

    private IEnumerator SweepShootCoroutine()
    {
        while (sweepShoot)
        {
            if (rotateClockwise)
            {
                transform.RotateAround(pivotPoint.transform.position, Vector3.back, rotationSpeed * Time.deltaTime * sweepSpeed);
            }
            else if (!rotateClockwise)
            {
                transform.RotateAround(pivotPoint.transform.position, Vector3.forward, rotationSpeed * Time.deltaTime * sweepSpeed);

            }
            yield return null;
        }
    }
}

