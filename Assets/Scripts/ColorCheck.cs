using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCheck : MonoBehaviour
{
    [SerializeField] Material[] colorMaterials; 
    [SerializeField]private MeshRenderer playerRenderer; 
    private float colorChangeInterval = 2f;
    private int currentColorIndex = 0;

    public delegate void ColorMismatch();
    public static event ColorMismatch OnColorMismatch;

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

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.layer == 6) {
            Renderer platformRenderer = other.gameObject.GetComponent<MeshRenderer>();
            if(platformRenderer.sharedMaterial != playerRenderer.sharedMaterial) {
                OnColorMismatch?.Invoke();
            }
        }
    }
}
