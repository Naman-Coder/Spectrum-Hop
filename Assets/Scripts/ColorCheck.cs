using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCheck : MonoBehaviour
{
    [SerializeField] Material[] colorMaterials; 
    [SerializeField]private Renderer playerRenderer; 
    private float colorChangeInterval = 2f;
    private int currentColorIndex = 0;

    private void Start()
    {
        StartCoroutine(ColorChangeCoroutine());
    }

    private IEnumerator ColorChangeCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(colorChangeInterval);

            currentColorIndex = (currentColorIndex + 1) % colorMaterials.Length;
            playerRenderer.material = colorMaterials[currentColorIndex];
        }
    }
}
