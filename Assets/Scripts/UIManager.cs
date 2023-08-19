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


    private void Awake() 
    {
        ShowCountDown();    
    }

    private void OnEnable() 
    {
        ColorCheck.OnColorMismatch += ShowGameOver;
        Countdown.OnGameStarted += ShowNextColorCounter;
    }

    private void OnDisable() 
    {
        ColorCheck.OnColorMismatch -= ShowGameOver;
        Countdown.OnGameStarted -= ShowNextColorCounter;
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

}
