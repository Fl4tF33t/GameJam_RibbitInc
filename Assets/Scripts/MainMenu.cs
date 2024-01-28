using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Awake()
    {
        Screen.SetResolution(1920, 1080, true);
    }
    public void Play()
    {
        SceneManager.LoadScene("Explain");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
