using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject countdown;
    [SerializeField] private GameObject nextColorCounter;
    [SerializeField] private GameObject score;
    [SerializeField] private GameObject jumpsRemaining;


    private void Awake() 
    {
        ShowCountDown();
    }

    private void OnEnable() 
    {
        ColorCheck.OnColorMismatch += ShowGameOver;
        Countdown.OnGameStarted += ShowNextColorCounter;
        Countdown.OnGameStarted += ShowScore;
        Countdown.OnGameStarted += ShowJumpsRemaining;
        PlayerController.OnOutOfBounds += ShowGameOver;
    }

    private void OnDisable() 
    {
        ColorCheck.OnColorMismatch -= ShowGameOver;
        Countdown.OnGameStarted -= ShowNextColorCounter;
        Countdown.OnGameStarted -= ShowJumpsRemaining;
        Countdown.OnGameStarted -= ShowScore;
        PlayerController.OnOutOfBounds -= ShowGameOver;
    }

    private void ShowJumpsRemaining()
    {
        jumpsRemaining.SetActive(true);
    }

    private void ShowGameOver()
    {
        gameOver.SetActive(true);
        Time.timeScale = 0;
    }

    public void ShowCountDown()
    {
        countdown.SetActive(true);
    }

    private void ShowNextColorCounter()
    {
        nextColorCounter.SetActive(true);
    }
    
    private void ShowScore()
    {
        score.SetActive(true);
    }

}
