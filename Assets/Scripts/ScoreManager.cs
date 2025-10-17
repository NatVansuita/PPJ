using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [Header("UI")]
    public Text scoreText;
    public Text highScoreText;
    public Text timeText;
    public Text bestTimeText;

    private int score = 0;
    private int highScore = 0;

    private float survivalTime = 0f;
    private float bestSurvivalTime = 0f;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        bestSurvivalTime = PlayerPrefs.GetFloat("BestSurvivalTime", 0f);
    }

    void Update()
    {
        survivalTime += Time.deltaTime;

        timeText.text = "Tempo: " + Mathf.FloorToInt(survivalTime).ToString() + "s";
        bestTimeText.text = "Melhor Tempo: " + Mathf.FloorToInt(bestSurvivalTime).ToString() + "s";
        scoreText.text = "Prêmios: " + score.ToString();
        highScoreText.text = "Recorde de Prêmios: " + highScore.ToString();
    }

    // Chame este método quando o jogador coletar um prêmio:
    public void CollectPrize()
    {
        score++;
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }

    // Chame este método quando o jogador morrer:
    public void OnPlayerDeath()
    {
        if (survivalTime > bestSurvivalTime)
        {
            bestSurvivalTime = survivalTime;
            PlayerPrefs.SetFloat("BestSurvivalTime", bestSurvivalTime);
        }
    }
}