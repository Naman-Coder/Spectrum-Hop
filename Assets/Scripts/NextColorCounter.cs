using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NextColorCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nextColorCounterText;
    [SerializeField] private ColorCheck colorCheck;

    private float counter = 5f;

    private void Update() 
    {
        counter-= Time.deltaTime;
        if(counter <= 0f)
        {
            counter = 5f;
        }
        if(colorCheck.currentColorIndex == 0)
            nextColorCounterText.text = $"NEXT COLOR IN: <color=#00FF00>{counter:F2}</color>";
        else if(colorCheck.currentColorIndex == 1)
            nextColorCounterText.text = $"NEXT COLOR IN: <color=#0000FF>{counter:F2}</color>";
        else if(colorCheck.currentColorIndex == 2)
            nextColorCounterText.text = $"NEXT COLOR IN: <color=#FF0000>{counter:F2}</color>";
    }

}
