using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOver;

    
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
        Debug.Log("Game overi des");
    }
}
