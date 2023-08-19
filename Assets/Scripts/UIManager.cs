using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject countdown;
    [SerializeField] private GameObject nextColorCounter;
    [SerializeField] private GameObject score;


    private void Awake() 
    {
        ShowCountDown();    
    }

    private void OnEnable() 
    {
        ColorCheck.OnColorMismatch += ShowGameOver;
        Countdown.OnGameStarted += ShowNextColorCounter;
        Countdown.OnGameStarted += ShowScore;
    }

    private void OnDisable() 
    {
        ColorCheck.OnColorMismatch -= ShowGameOver;
        Countdown.OnGameStarted -= ShowNextColorCounter;
        Countdown.OnGameStarted -= ShowScore;
    }

    private void ShowGameOver()
    {
        gameOver.SetActive(true);
        Time.timeScale = 0;
    }

    private void ShowCountDown()
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
