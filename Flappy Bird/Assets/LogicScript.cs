using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore = 0;
    public PlayerPrefs highScore;
    public int currentHighScore;
    public Text scoreText;
    public Text highScoreText;
    public GameObject gameOverScreen;
    public AudioSource ding;

    public void Start()
    {
        currentHighScore = PlayerPrefs.GetInt("highScore", 0);
        highScoreText.text = "High Score: " + currentHighScore.ToString();
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd = 1)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);

        if (playerScore > currentHighScore)
        {
            currentHighScore = playerScore;
            PlayerPrefs.SetInt("highScore", currentHighScore);
            highScoreText.text = "High Score: " + currentHighScore.ToString();
        }
    }
}
