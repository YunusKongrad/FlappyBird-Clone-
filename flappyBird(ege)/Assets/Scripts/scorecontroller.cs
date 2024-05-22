using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scorecontroller : MonoBehaviour
{
    public Text ScoreText,HightScoreText;

    public int score = 0;

    public GameObject GameOverPanel, GamePanel, AnamenuPanel;
    public Text ScoreGO, HighScoreGO;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            score += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOverPanel.activeInHierarchy)
        {
            if (score > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", score);
            }

            HighScoreGO.text = "HighScore : " + PlayerPrefs.GetInt("HighScore").ToString();
            ScoreGO.text = "Score : " + score.ToString();
        }

        if (GamePanel.activeInHierarchy)
        {
            ScoreText.text = "Score: " + score.ToString();
            if (score < PlayerPrefs.GetInt("HighScore"))
            {
                HightScoreText.text = "HighScore : " + PlayerPrefs.GetInt("HighScore").ToString();
            }
            else
            {
                PlayerPrefs.SetInt("HighScore", score);
                HightScoreText.text = "HighScore : " + PlayerPrefs.GetInt("HighScore").ToString();
                HightScoreText.color = Color.red;
            }
                
        }
    }

    public void AnaMenuButton()
    {
        score = 0;
        AnamenuPanel.SetActive(true);
    }

    // public void HighScoreSifirla()
    // {
    //     PlayerPrefs.GetInt("HighScore", 0);
    // } highscore sifirlama butonu eklenecekti.
    
}