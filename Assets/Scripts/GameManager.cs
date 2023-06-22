using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    

    [Header("Score Elements")]
    public int score;
    public int highScore;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    [Header("Game Over")]
    public GameObject gameOverPanel;
    public TextMeshProUGUI gameOverScoreText;
    public TextMeshProUGUI gameOverHighScoreText;

    private void Awake()
    {
        gameOverPanel.SetActive(false);
        GetHighScore();
    }

    private void GetHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = "Best: " + highScore.ToString();
    }

    public void IncreaseScore(int points)
    {
        score += points;
        scoreText.text = score.ToString();

        if(score > highScore)
        {
            PlayerPrefs.SetInt("HighScore",score);
            highScoreText.text = score.ToString();
        }
    }

    public void OnBombHit()
    {
        Time.timeScale = 0;

        gameOverScoreText.text = "Score: " + score.ToString();
        gameOverHighScoreText.text = "High Score: " + highScore.ToString();

        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        score = 0;
        scoreText.text = score.ToString();

        gameOverPanel.SetActive(false);

        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Interactable"))
        {
            Destroy(g);
        }

        Time.timeScale = 1;

    }
}
