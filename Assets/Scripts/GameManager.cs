using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public bool isGameStarted = false;
    public float timer = 0f;
    public int playerScore = 0;

    public float player1Time = 0f;
    public float player2Time = 0f;


    // Update is called once per frame
    void Update()
    {
        if (isGameStarted)
        {
            if(playerScore != 5)
            {
                timer += Time.deltaTime; // Time.deltaTime is the time between frames
            }  
            else if (playerScore == 5)
            {
                player1Time = timer;
                timer = 0f;
                playerScore = 0;
                isGameStarted = false;
                Debug.Log("Player 1 Wins!");
            }
        }   
    }
}
