using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    
    public TextMeshProUGUI countdownText;
    public float countdownDuration = 3.0f;          

    public delegate void GameStarted();
    public static event GameStarted OnGameStarted;

    private void Start()
    {
        StartCoroutine(StartCountdown());
    }

    private void Update() 
    {
            
    }

    private IEnumerator StartCountdown()
    {
        countdownText.text = "3";
        yield return new WaitForSecondsRealtime(1f);

        countdownText.text = "2";
        yield return new WaitForSecondsRealtime(1f);

        countdownText.text = "1";
        yield return new WaitForSecondsRealtime(1f);

        countdownText.text = "Go!";
        yield return new WaitForSecondsRealtime(1f);

        gameObject.SetActive(false);
        Time.timeScale = 1;
        OnGameStarted?.Invoke();
    }
}

