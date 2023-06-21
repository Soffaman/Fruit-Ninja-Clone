using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    

    [Header("Score Elements")]
    public int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    [Header("Game Over")]
    public GameObject gameOverPanel;

    private void Awake()
    {
        highScoreText.text = "Best: " + GetHighScore().ToString();
        gameOverPanel.SetActive(false);
    }

    public void IncreaseScore(int points)
    {
        score += points;
        scoreText.text = score.ToString();

        if (score > GetHighScore())
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = "Best: " + score.ToString();
        }
    }

    public int GetHighScore()
    {
        int i = PlayerPrefs.GetInt("HighScore");
        return i;
    }

    public void OnBombHit()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("Bomb hit");
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        score = 0;
        scoreText.text = "0";

        gameOverPanel.SetActive(false);

        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Interactable"))
        {
            Destroy(g);
        }

    }
}
