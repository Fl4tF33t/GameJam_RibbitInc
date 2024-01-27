using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
    }
}
