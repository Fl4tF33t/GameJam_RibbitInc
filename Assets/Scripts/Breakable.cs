using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    public bool isBreakable = false;

    void OnCollisionStay(Collision collision)
    {
        if (isBreakable && collision.gameObject.CompareTag("Player"))
        {
            // Platform is breakable, perform breaking logic here
            BreakPlatform();
        }
    }

    void BreakPlatform()
    {
        // Implement your breaking logic here
        Debug.Log("Platform is breaking!");
        Destroy(gameObject);
    }
}
