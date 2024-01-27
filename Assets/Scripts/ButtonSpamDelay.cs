using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSpamDelay : MonoBehaviour
{
    Button button;
    public float delay = 1f;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    public void DisableButton()
    {
        button.interactable = false;
        StartCoroutine(EnableButton());
    }

    private IEnumerator EnableButton()
    {
        yield return new WaitForSeconds(delay);
        button.interactable = true;
    }
}
