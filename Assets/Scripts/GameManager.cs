using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private bool gameOver;

    private void OnEnable() 
    {
        ColorCheck.OnColorMismatch += SetBool;
    }

    private void OnDisable() 
    {
        ColorCheck.OnColorMismatch -= SetBool;
    }

    void Awake()
    {
        Time.timeScale = 0;
        Instance = this;
    }

    void Update()
    {
        ResetGame();
    }

    private void ResetGame() 
    {
        if(gameOver && Input.GetKeyDown(KeyCode.Return))
            SceneManager.LoadScene("SampleScene");
    }

    private void SetBool()
    {
        gameOver = true;
    }


}
