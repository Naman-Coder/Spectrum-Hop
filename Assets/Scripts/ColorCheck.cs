using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCheck : MonoBehaviour
{
    [SerializeField] Material[] colorMaterials; 
    [SerializeField]private MeshRenderer playerRenderer; 
    public float colorChangeInterval = 5f;
    public int currentColorIndex = 0;

    public delegate void ColorMismatch();
    public static event ColorMismatch OnColorMismatch;

    private void Start()
    {
        currentColorIndex = Random.Range(0, colorMaterials.Length);
        playerRenderer.material = colorMaterials[currentColorIndex]; // Apply a random color when game starts
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

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.layer == 6) {
            Renderer platformRenderer = other.gameObject.GetComponent<MeshRenderer>();
            if(platformRenderer.sharedMaterial != playerRenderer.sharedMaterial) {
                OnColorMismatch?.Invoke();
            }
        }
    }
}
