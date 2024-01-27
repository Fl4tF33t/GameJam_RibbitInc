using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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

    public static int player1Score = 0;
    public static int player2Score = 0;
    public static float player1Time = 0f;
    public static float player2Time = 0f;

    public TextMeshProUGUI player1TimerText;
    public TextMeshProUGUI player2TimerText;
    public TextMeshProUGUI player1ScoreText;
    public TextMeshProUGUI player2ScoreText;


    //Gameplay SHIT
    public GameObject collectablePrefab;
    public GameObject baitPrefab;
    public Transform[] spawnPoint;
    public float countdown;
    public TextMeshProUGUI countdownText;
    bool autoTurn = true;

    //SceneShit
    public event EventHandler OnGameEnd;
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

        player1TimerText.text = "P1 Time: " + player1Time.ToString();
        player2TimerText.text = "P2 Time: " + player2Time.ToString();
        player1ScoreText.text = "Score: " + player1Score.ToString();
        player2ScoreText.text = "Score: " + player2Score.ToString();

        if (isGameStarted)
        {
            AutoSwitch();

            if(currentPlayer == Player.Player1)
            {
                if(player1Score < 5)
                {
                    player1Time += Time.deltaTime;
                }
                if(player1Score == 5)
                {
                    autoTurn = false; 
                }
            }
            else if(currentPlayer == Player.Player2)
            {
                if (player2Score < 5)
                {
                    player2Time += Time.deltaTime;
                }
                if(player2Score == 5)
                {
                    if(player2Time < player1Time)
                    {
                        Debug.Log("Player 2 Wins");
                    }
                    else
                    {
                        Debug.Log("Player 1 Wins");
                    }
                }
            }
        }
    }

    void AutoSwitch()
    {
        if(autoTurn)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= switchTime)
            {
                elapsedTime = 0f;
                isGameStarted = false;
                SwitchSides();
            }
        }
    }   
    void CountDownPlayerSwitch()
    {
        if (!isGameStarted)
        {
            countdownText.transform.gameObject.SetActive(true);
            countdown -= Time.deltaTime;
            countdownText.text = "Get Ready: " + countdown.ToString();
        }
        if (countdown < 0)
        {
            isGameStarted = true;
            countdownText.transform.gameObject.SetActive(false);
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
