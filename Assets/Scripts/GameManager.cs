using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    //PLAYER SHIT
    public enum Player
    {
        Player1,
        Player2
    }

    public Player currentPlayer;

    public bool isGameStarted = false;

    private float elapsedTime = 0f;
    public float switchTime = 10f;

    public int player1Score = 0;
    public int player2Score = 0;
    public float player1Time = 0f;
    public float player2Time = 0f;

    public TextMeshProUGUI player1TimerText;
    public TextMeshProUGUI player2TimerText;
    public TextMeshProUGUI player1ScoreText;
    public TextMeshProUGUI player2ScoreText;
    public Image swapImage;
    public static bool p2Win;

    //Gameplay SHIT
    public GameObject collectablePrefab;
    public GameObject baitPrefab;
    public Transform[] spawnPoint;
    public float countdown;
    public TextMeshProUGUI countdownText;
    bool autoTurn = true;

    //SceneShit
    public event Action<bool> OnGameEnd;

    public int amountLimit;
    private void Start()
    {
        currentPlayer = Player.Player1;
        SpawnCollectable();
    }

    //Dexter Shit
    public int currentlySpawned = 0;

    // Update is called once per frame
    void Update()
    {
        CountDownPlayerSwitch();

        player1TimerText.text = "P1 Time: " + Mathf.Round(player1Time).ToString();
        player2TimerText.text = "P2 Time: " + Mathf.Round(player2Time).ToString();
        player1ScoreText.text = "Score: " + player1Score.ToString();
        player2ScoreText.text = "Score: " + player2Score.ToString();

        if (isGameStarted)
        {
            if(autoTurn)
            {
                AutoSwitch();
            }

            if(currentPlayer == Player.Player1)
            {
                if(player1Score < amountLimit)
                {
                    player1Time += Time.deltaTime;
                }
                if(player1Score == amountLimit)
                {
                    autoTurn = false;
                    isGameStarted = false;
                    SwitchSides();
                }
            }
            else if(currentPlayer == Player.Player2)
            {
                if (player2Score == amountLimit)
                {
                    //you win
                    p2Win = true;
                    SceneManager.LoadScene("End");
                }
                if (player2Score < amountLimit)
                {
                    player2Time += Time.deltaTime;
                }
                if(autoTurn == false && player2Time > player1Time)
                {
                    p2Win = false;
                    SceneManager.LoadScene("End");
                    //loose the game
                }
            }
        }
    }

    void AutoSwitch()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= switchTime)
        {
            elapsedTime = 0f;
            isGameStarted = false;

            SwitchSides();
        }
    }   
    void CountDownPlayerSwitch()
    {
        if (!isGameStarted)
        {
            countdownText.transform.gameObject.SetActive(true);
            swapImage.gameObject.SetActive(true);
            countdown -= Time.deltaTime;
            countdownText.text = "Get Ready: " + countdown.ToString();
        }
        if (countdown < 0)
        {
            isGameStarted = true;
            countdownText.transform.gameObject.SetActive(false);
            swapImage.gameObject.SetActive(false);
            countdown = 3;
        }
    }

    public void SwitchSides()
    {
        if (currentPlayer == Player.Player1)
        {
            currentPlayer = Player.Player2;
            DestroyExistingCol();
            SpawnCollectable();
        }
        else
        {
            currentPlayer = Player.Player1;
            DestroyExistingCol();
            SpawnCollectable();
        }
    }

    void SpawnCollectable()
    {
        int index = UnityEngine.Random.Range(0, spawnPoint.Length);
        currentlySpawned = index;
        Instantiate(collectablePrefab, spawnPoint[index].position, Quaternion.identity);
    }

    public void SpawnBait()
    {
        Debug.Log("button");
        int index = UnityEngine.Random.Range(0, spawnPoint.Length);
        while (index == currentlySpawned)
        {
            Debug.Log("while");
            index = UnityEngine.Random.Range(0, spawnPoint.Length);
            if (index != currentlySpawned)
            {
                Debug.Log("break");
                break;
            }
        }
        Debug.Log("spawn");
        Instantiate(baitPrefab, spawnPoint[index].position, Quaternion.identity);

    }
    public void DestroyCollectable(GameObject collectable)
    {
        if (currentPlayer == Player.Player1)
        {
            player1Score += 1;
        }
        else if(currentPlayer == Player.Player2)
        {
            player2Score += 1;
        }
        Destroy(collectable);
        SpawnCollectable();
    }

    private void DestroyExistingCol()
    {
        GameObject destroyCollectable = GameObject.FindGameObjectWithTag("Collectable");
        if (destroyCollectable != null)
        {
            Destroy(destroyCollectable);
        }
    }

}
