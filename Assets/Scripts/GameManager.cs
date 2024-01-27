using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public enum Player
    {
        Player1,
        Player2
    }

    public Player currentPlayer;

    public bool isGameStarted = false;
    bool isGamePaused = false;

    public int playerScore = 0;

    public static int player1Score = 0;
    public static int player2Score = 0;

    public static float player1Time = 0f;
    public static float player2Time = 0f;

    public TextMeshProUGUI player1TimerText;
    public TextMeshProUGUI player2TimerText;
    public TextMeshProUGUI player1ScoreText;
    public TextMeshProUGUI player2ScoreText;

    private void Start()
    {
        currentPlayer = Player.Player1;
    }

    // Update is called once per frame
    void Update()
    {
        player1TimerText.text = "P1 Time: " + player1Time.ToString();
        player2TimerText.text = "P2 Time: " + player2Time.ToString();
        player1ScoreText.text = "Score: " + player1Score.ToString();
        player2ScoreText.text = "Score: " + player2Score.ToString();
        if (isGameStarted)
        {
            if(currentPlayer == Player.Player1)
            {
                player1Time += Time.deltaTime;
            }
            else if(currentPlayer == Player.Player2)
            {
                 player2Time += Time.deltaTime;
            }
        }
        if (isGamePaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void SwitchSides()
    {
        if (currentPlayer == Player.Player1)
        {
            currentPlayer = Player.Player2;
        }
        else
        {
            currentPlayer = Player.Player1;
        }
    }

    public void Collectable(GameObject collectable)
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
    }


}
