using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JumpsRemainingText : MonoBehaviour
{
    private TextMeshProUGUI jumpsRemainingText;
    [SerializeField] private PlayerController playerController;
    private void Start()
    {
        jumpsRemainingText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        jumpsRemainingText.text = "JUMPS REMAINING: " + playerController.remainingJumps;
    }
}
