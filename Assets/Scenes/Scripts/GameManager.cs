using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public GameObject starPrefab;
    public TextMeshProUGUI scoreText;

    private int score = 30;
    public int Score => score;

    void Start()
    {
        UpdateScoreUI();
        StartCoroutine(SpawnAsteroidRoutine());
        StartCoroutine(SpawnStarRoutine());
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreUI();
    }

    public void DeductScore(int points)
    {
        score -= points;
        UpdateScoreUI();

        if (score <= 0)
        {
            score = 0;
            
            AudioSource cameraAudio = Camera.main.GetComponent<AudioSource>();
            if (cameraAudio != null)
            {
                cameraAudio.Stop();
            }

            PlayerPrefs.SetInt("FinalScore", score);
            PlayerPrefs.Save();
            SceneManager.LoadScene("EndGame");
        }
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    IEnumerator SpawnAsteroidRoutine()
    {
        while (true)
        {
            float randomX = Random.Range(-8f, 8f);
            Instantiate(asteroidPrefab, new Vector3(randomX, 6f, 0f), Quaternion.identity);
            yield return new WaitForSeconds(2f);
        }
    }

    IEnumerator SpawnStarRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3f, 5f));
            float randomX = Random.Range(-8f, 8f);
            Instantiate(starPrefab, new Vector3(randomX, 6f, 0f), Quaternion.identity);
        }
    }
}