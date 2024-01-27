using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public AudioClip audioClip;
    AudioSource audioSource;
    private void Start()
    {
        audioSource = GameObject.Find("Manager").GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.PlayOneShot(audioClip);
            GameManager.Instance.DestroyCollectable(this.gameObject);
        }
    }
}
