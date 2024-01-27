using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    Rigidbody rb;
    public Transform jumpDirecrtion;
    public float jumpForce;
    Vector3 jump;
    bool isGrounded;

    private Coroutine coroutine;
    private RotateAroundPivot rotateAroundPivot;

    public bool isGravityReversed = false;
    public float rotationSpeed = 5f;

    public GameObject breakable = null;

    public Animator anim;

    public GameObject visual;

    public AudioSource audioSource;
    public AudioClip audioClip;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rotateAroundPivot = GetComponentInChildren<RotateAroundPivot>();
    }

    // Update is called once per frame
    void Update()
    {
        jump = jumpDirecrtion.position - transform.position;
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded && GameManager.Instance.isGameStarted)
        {
            GameObject bait = GameObject.FindGameObjectWithTag("Bait");
            if (bait!=null)
            {
                Vector3 direction = (bait.transform.position - transform.position).normalized;
                rb.AddForce(direction * 35f, ForceMode.Impulse);
                Destroy(bait);
            }
            else if(bait == null)
            {
                rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            }
            anim.SetBool("OnJump", true);
            audioSource.PlayOneShot(audioClip);
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
        anim.SetBool("OnJump", false);
        anim.SetBool("OnLanding", true);
        if (collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("Plane"))
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
            }
            coroutine = StartCoroutine(Grounded());
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("Platform"))
        {
            breakable = collision.gameObject;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
        anim.SetBool("OnLanding", false);
    }

    private IEnumerator Grounded()
    {
        yield return new WaitForSeconds(1f);
        isGrounded = true;

    }
}
