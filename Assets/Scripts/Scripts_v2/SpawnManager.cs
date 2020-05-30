using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> gameElementsUpper;
    public List<GameObject> gameElementsLower;
    public List<GameObject> lanterns;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen;

    private float spawnPosX = 195;
    private float spawnPosYUpper = 70;
    private float spawnPosYLower = 58.65f;
    private float spawnPosYLanternU = 65;
    private float spawnPosYLanternL = 60;
    private float spawnPosZ = 74.5f;

    public bool gameOver;

    private PlayerController playerController;

    public bool isGameRunning;
    private int score;

    class SpawnRate
    {
        private float baseRate;
        private int difficulty;

        public SpawnRate(int diff)
        {
            baseRate = Random.Range(1.5f, 1.75f);
            difficulty = diff;
        }

        public float GetRate()
        {
            return baseRate / difficulty;
        }
    }
    private SpawnRate spawnRate;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        score = 0;
        gameOver = false;
    }

    public void StartGame(int difficulty)
    {
        spawnRate = new SpawnRate(difficulty);
        Debug.Log("Spawn Rate =" + spawnRate);
        titleScreen.gameObject.SetActive(false);
        isGameRunning = true;
        StartCoroutine(SpawnRandomLanterns());
        StartCoroutine(SpawnRandomElements());
        UpdateScore(0);
    }

    IEnumerator SpawnRandomElements()
    {
        while (isGameRunning)
        {
            yield return new WaitForSeconds(spawnRate.GetRate());
            int x = Random.Range(0, 2);
            switch (x)
            {
                case 0:
                    Vector3 spawnPosL = new Vector3(spawnPosX, spawnPosYLower, spawnPosZ);
                    int elementIndexL = Random.Range(0, gameElementsLower.Count);
                    Instantiate(gameElementsLower[elementIndexL], spawnPosL, gameElementsLower[elementIndexL].transform.rotation);
                    break;
                case 1:
                    Vector3 spawnPosU = new Vector3(spawnPosX, spawnPosYUpper, spawnPosZ);
                    int elementIndexU = Random.Range(0, gameElementsUpper.Count);
                    Instantiate(gameElementsUpper[elementIndexU], spawnPosU, gameElementsUpper[elementIndexU].transform.rotation);
                    break;
            }
        }
    }

    IEnumerator SpawnRandomLanterns()
    {
        while (isGameRunning)
        {
            yield return new WaitForSeconds(Random.Range(0.25f, 0.5f));
            int x = Random.Range(0, 2);
            switch (x)
            {
                case 0:
                    Vector3 spawnPosU = new Vector3(spawnPosX, spawnPosYLanternU, spawnPosZ);
                    int elementIndexU = Random.Range(0, lanterns.Count);
                    Instantiate(lanterns[elementIndexU], spawnPosU, lanterns[elementIndexU].transform.rotation);
                    break;
                case 1:
                    Vector3 spawnPosL = new Vector3(spawnPosX, spawnPosYLanternL, spawnPosZ);
                    int elementIndexL = Random.Range(0, lanterns.Count);
                    Instantiate(lanterns[elementIndexL], spawnPosL, lanterns[elementIndexL].transform.rotation);
                    break;
            }
        }
    }

    public void UpdateScore(int delta)
    {
        if (isGameRunning)
        {
            score += delta;
            if (score < 0)
            {
                score = 0;
            }
            scoreText.text = "Score: " + score;
        }
    }

    void Update()
    {
        if (playerController.gameOver == true)
        {
            StopCoroutine(SpawnRandomElements());
            StopCoroutine(SpawnRandomLanterns());
        }
    }

    public void GameOver()
    {
        gameOver = true;
        isGameRunning = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
