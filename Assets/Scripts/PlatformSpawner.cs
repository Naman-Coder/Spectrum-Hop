using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] platformPrefabs;
    [SerializeField] private ColorCheck colorCheck;
    [SerializeField] private Vector3 spawnPoint = new (0f, 0f, 1.4f);
    [SerializeField] private float spawnPointIncrement = 1.4f; 

    private bool isCorrectPlatformSpawned;
         

    private void Start() {
        
    }

    private void Update()
    {
        
    }

    public void SpawnPlatform()
    {
        //Spawns platforms alternatively
        if(!isCorrectPlatformSpawned)
        {
            Instantiate(platformPrefabs[colorCheck.currentColorIndex], spawnPoint, Quaternion.identity, transform);
            isCorrectPlatformSpawned = true;
        }
        else
        {
            Instantiate(platformPrefabs[RandomExcept(0, platformPrefabs.Length, colorCheck.currentColorIndex)], spawnPoint, Quaternion.identity, transform);
            isCorrectPlatformSpawned = false;
        }

        foreach (Transform child in transform) // Changes instantiated objects' layer
        {
            child.gameObject.layer = 6;
        }
        spawnPoint += new Vector3(0f, 0f, spawnPointIncrement);
    }

    private int RandomExcept(int min, int max, int except)
    {
        int random = Random.Range(min, max);
        if (random == except) random = (random + 1) % max;
        return random;
    }
}
