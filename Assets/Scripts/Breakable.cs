using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    public bool isBreakable = false;
    MakeBreakable makeBreakable;

    private void Awake()
    {
        makeBreakable = GameObject.Find("Manager").GetComponent<MakeBreakable>();
    }

    private void OnEnable()
    {
        isBreakable = false;
    }

    void OnCollisionStay(Collision collision)
    {
        if (isBreakable && collision.gameObject.CompareTag("Player"))
        {
            // Platform is breakable, perform breaking logic here
            makeBreakable.Inactive(gameObject);
        }
    }

    /*void BreakPlatform()
    {
        // Implement your breaking logic here
        Debug.Log("Platform is breaking!");
        Destroy(gameObject);
    }*/
}
