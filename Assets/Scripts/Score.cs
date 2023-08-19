using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private float counter = 0f;

    private void Update() 
    {
        counter += Time.deltaTime;
        scoreText.text = string.Format("Score: {0:0.}", counter);
    }
}
