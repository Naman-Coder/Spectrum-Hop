using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip mainMusic;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable() 
    {
        Countdown.OnGameStarted += PlayMusic;
        ColorCheck.OnColorMismatch += StopMusic;
    }

    private void OnDisable() {
        Countdown.OnGameStarted -= PlayMusic;
        ColorCheck.OnColorMismatch -= StopMusic;
    }

    private void PlayMusic()
    {
        audioSource.PlayOneShot(mainMusic, 0.5f);
    }

    private void StopMusic()
    {
        audioSource.Stop();
    }
}
