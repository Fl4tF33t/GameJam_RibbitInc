using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour
{
    public GameObject Win1;
    public GameObject Win2;

    private void Awake()
    {
        if (GameManager.Instance.player1Score==1)
        {

        }
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
    }

}
