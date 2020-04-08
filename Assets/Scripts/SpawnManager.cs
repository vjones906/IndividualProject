using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] raindropPrefabs;

    private float spawnLimitXLeft = -225;
    private float spawnLimitXRight = 200;
    private float spawnPosY = 50;

    private float startDelay = 1.0f;
    private float minSpawnInterval = 0f;
    private float maxSpawnInterval = 0.5f;
    private float spawnInterval;

    // Start is called before the first frame update
    void Start()
    {
        float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
        InvokeRepeating("SpawnRandomRaindrop", startDelay, spawnInterval);
    }

    // Spawn random raindrop at random x position above of play area
    void SpawnRandomRaindrop()
    {
        // Generate random raindrop index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);
        int randomRaindrop = Random.Range(0, raindropPrefabs.Length);
        // Instantiate raindrop at random spawn location
        Instantiate(raindropPrefabs[randomRaindrop], spawnPos, raindropPrefabs[randomRaindrop].transform.rotation);
    }

}
