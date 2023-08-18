using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject countdown;

    private void Awake() 
    {
        ShowCountDown();    
    }

    private void OnEnable() 
    {
        ColorCheck.OnColorMismatch += ShowGameOver;
    }

    private void OnDisable() 
    {
        ColorCheck.OnColorMismatch -= ShowGameOver;
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


}
