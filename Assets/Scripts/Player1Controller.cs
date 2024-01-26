using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    Rigidbody rb;
    public Transform jumpDirecrtion;
    public float jumpForce = 10f;
    Vector3 jump;
    bool isGrounded;

    private Coroutine coroutine;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        jump = jumpDirecrtion.position - transform.position;
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.velocity = Vector3.zero;
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(NotGrounded());
        
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }

    private IEnumerator NotGrounded()
    {
        yield return new WaitForSeconds(0.5f);
        isGrounded = true;
    }
}
