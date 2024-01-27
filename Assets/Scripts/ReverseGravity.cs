using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseGravity : MonoBehaviour
{
    [SerializeField] private bool isGravityReversed = false;
    public float wait = 5f;

    Player1Controller player1Controller;

    private void Start()
    {
        player1Controller = GameObject.Find("Player1").GetComponent<Player1Controller>();
    }
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
       StartCoroutine( WaitForSeconds(wait));   
    }

    IEnumerator WaitForSeconds(float seconds)
    {
        player1Controller.isGravityReversed = !player1Controller.isGravityReversed;
        isGravityReversed = !isGravityReversed;
        yield return new WaitForSeconds(seconds);
        isGravityReversed = !isGravityReversed;
        player1Controller.isGravityReversed = !player1Controller.isGravityReversed;
    }
}
