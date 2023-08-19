using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NextColorCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nextColorCounterText;

    private float counter = 5f;

    private void Update() 
    {
        counter-= Time.deltaTime;
        if(counter <= 0f)
        {
            counter = 5f;
        }
        nextColorCounterText.text = string.Format("Next color in: {0:0.#}", counter);
    }

}
