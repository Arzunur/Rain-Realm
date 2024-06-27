using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class Enemy : MonoBehaviour
{
    public GameObject gameOverPanel; 
    public TextMeshProUGUI gameOverScoreText; 
    private ScoreManager scoreManager;
  
    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }
    private void OnEnable() => EnemySpawner.Ins.AddEnemyUfo(gameObject);
    private void OnDisable() => EnemySpawner.Ins.RemoveEnemyUfo(gameObject);

    private void OnTriggerEnter(Collider other)
    {
        PlayerController playerController = other.GetComponent<PlayerController>();

        if (playerController != null)
        {
            Time.timeScale = 0;

            if (scoreManager != null && gameOverScoreText != null)
            {
                gameOverScoreText.text = "SCORE: " + scoreManager.TotalScore;
            }

            if (gameOverPanel != null)
            {
                gameOverPanel.SetActive(true);
            }
            SoundManager.Instance.PlayEnemyHitSound();
        }
    }
}

