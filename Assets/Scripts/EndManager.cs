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
        if (GameManager.p2Win == true)
        {
            Win2.gameObject.SetActive(true);
        }
        else if (GameManager.p2Win==false)
        {
            Win1.gameObject.SetActive(true);
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
