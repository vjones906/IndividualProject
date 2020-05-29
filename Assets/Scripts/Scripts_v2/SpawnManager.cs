using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> raindrops;
    public List<GameObject> lantern;

    private float spawnLimitXLeft = -225;
    private float spawnLimitXRight = 200;
    private float spawnPosY = 50;

    private float startDelay = 1.0f;
    private float minSpawnInterval = 0f;
    private float maxSpawnInterval = 0.5f;
    private float spawnInterval;

    public bool gameOver = false;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRandomRaindrops());
        StartCoroutine(SpawnRandomLanterns());
    }

    IEnumerator SpawnRandomRaindrops()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);
            int raindropIndex = Random.Range(0, raindrops.Count);
            Instantiate(raindrops[raindropIndex], spawnPos, raindrops[raindropIndex].transform.rotation);
        }
    }

    IEnumerator SpawnRandomLanterns()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), 5, 0);
            int lanternIndex = Random.Range(0, lantern.Count);
            Instantiate(lantern[lanternIndex], spawnPos, lantern[lanternIndex].transform.rotation);
        }
    }

    void Update()
    {
        if (gameOver = true)
        {
            StopCoroutine(SpawnRandomRaindrops());
        }
    }

}
