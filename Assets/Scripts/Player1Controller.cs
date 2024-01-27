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
    private RotateAroundPivot rotateAroundPivot;

    public bool isGravityReversed = false;
    public float rotationSpeed = 5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rotateAroundPivot = GetComponentInChildren<RotateAroundPivot>();
    }

    // Update is called once per frame
    void Update()
    {
        jump = jumpDirecrtion.position - transform.position;
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            if (rotateAroundPivot.sweepShoot)
            {
                rotateAroundPivot.sweepShoot = false;
            }
        }

        if (isGravityReversed)
        {
            // Rotate towards the desired rotation (180 degrees around the z-axis)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 180), Time.deltaTime * rotationSpeed);
        }
        else
        {
            // Rotate towards the desired rotation (0 degrees around the z-axis)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * rotationSpeed);
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
