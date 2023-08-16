using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] platformPrefabs;
    private Vector3 spawnPoint = new (0f, 0f, 1.5f);          
    private float spawnInterval = 0.5f;       
    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnPlatform();
            spawnPoint += new Vector3(0f, 0f, 1.5f);
            timer = 0f; 
        }
    }

    private void SpawnPlatform()
    {
        int randomIndex = Random.Range(0, platformPrefabs.Length);
        GameObject platformPrefab = platformPrefabs[randomIndex];

        Instantiate(platformPrefab, spawnPoint, Quaternion.identity, transform);
        foreach (Transform child in transform)
         {
            child.gameObject.layer = 6;
         }
    }
}
