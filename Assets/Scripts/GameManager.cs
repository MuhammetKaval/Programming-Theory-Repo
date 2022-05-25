using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private float spawnRate = 2.0f;
    private float score;
    
    // ENCAPSULATION
    public bool isGameActive { get; private set; }

    public TextMeshProUGUI scoreText;
    public List<GameObject> objects;
    public GameObject gameOverText;
    public GameObject restartButton;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        // ABSTRACTION
        StartGame();
    }

    public IEnumerator SpawnObject()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);

            Instantiate(objects[GetRandomIndex()]);
        }
    }

    
    public int GetRandomIndex()
    {
        int randomIndex = Random.Range(0, objects.Count);
        return randomIndex;
    }

    
    public void StartGame()
    {
        isGameActive = true;
        StartCoroutine(SpawnObject());
        gameOverText.SetActive(false);
        restartButton.SetActive(false);
        score = 0;
        scoreText.text = score.ToString();
    }

    public void RestartGame()
    {
        // ABSTRACTION
        StartGame();
    }
    
    public void UpdateScore(int scorePoint)
    {
        score += scorePoint;
        scoreText.text = score.ToString();
    }
    
    public void GameOver()
    {
        isGameActive = false;
        gameOverText.SetActive(true);
        restartButton.SetActive(true);
    }
}
