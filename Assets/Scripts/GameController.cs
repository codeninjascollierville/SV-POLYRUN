﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Text scoreText;
    int score = 0;
    void Start(){
        gameOverPanel.SetActive(false);
        scoreText.gameObject.SetActive(true);
    }

    public void GameOver()    
    {
        Time.timeScale = 0;
        scoreText.gameObject.SetActive(false);
        gameOverPanel.SetActive(true);
    }

    public void IncrementScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
