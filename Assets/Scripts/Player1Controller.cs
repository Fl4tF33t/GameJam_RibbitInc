using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    Rigidbody rb;
    public Transform jumpDirecrtion;
    Vector3 jump;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        jump = jumpDirecrtion.position - transform.position;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(jump * 5, ForceMode.Impulse);
        }

    }
}
