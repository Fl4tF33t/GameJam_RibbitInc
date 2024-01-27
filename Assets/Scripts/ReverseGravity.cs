using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseGravity : MonoBehaviour
{
    [SerializeField] private bool isGravityReversed = false;
    public float wait = 5f;
    void Update()
    {

        if (isGravityReversed)
        {
            Physics.gravity = new Vector3(0f, 9.81f, 0f); // Reverse gravity along the y-axis
        }
        // Restore normal gravity
        else
        {
            Physics.gravity = new Vector3(0f, -9.81f, 0f); // Set gravity along the y-axis (adjust as needed)
        }
    }

    public void ReverseGravityNow()
    {
        isGravityReversed = !isGravityReversed;
        WaitForSeconds(wait);
        isGravityReversed = !isGravityReversed;

    }

    IEnumerator WaitForSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}
