using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLife = 3;
    public int score  = 0;

    public TextMeshProUGUI lifeText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameScore;
    public int highScore;
    public TextMeshProUGUI highScoreSee;

    [SerializeField] GameObject gameOverPanel;
    ScoreCaller scoreCaller;
    sccreChecker scoreChecker;
    pause pausing;
    Player player;
    [SerializeField] GameObject pauseButton;



    private void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if(numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        lifeText.text = playerLife.ToString();
        scoreText.text = score.ToString();
        gameScore.text = score.ToString();
        highScore = PlayerPrefs.GetInt("highscore", highScore);
        highScoreSee.text = highScore.ToString();
        scoreChecker = GameObject.Find("ScoreChecker").GetComponent<sccreChecker>();
        pausing = FindObjectOfType<pause>();
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = score.ToString();
        gameScore.text = score.ToString();
    }

    public void ProcessPlayerDeath()
    {
        if (playerLife > 1)
        {
            scoreChecker.checker = true;
            TakeLife();
        }
        else
        {
            scoreChecker.checker = true;
            //ResetGameSession();
            Destroy(scoreChecker);
            if (scoreChecker.checker == true)
            {
                GameOverAnimation();
            }
        }
    }

    private void TakeLife()
    {
        scoreChecker.checker = true;
        playerLife--;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        scoreChecker.checker = true;
        SceneManager.LoadScene(currentSceneIndex);
        lifeText.text = playerLife.ToString();
    }

    public void ResetGameSession()
    {
        scoreChecker.checker = true;
        SceneManager.LoadScene(0);
        Destroy(gameObject);
        FindObjectOfType<ScenePersist>().Destroying();
        scoreChecker.checker = true;
    }
    public void RestartLevel()
    {
        scoreChecker.checker = true;
        SceneManager.LoadScene(2);
        Destroy(gameObject);
        FindObjectOfType<ScenePersist>().Destroying();
        scoreChecker.checker = true;
    }
    public void loadEndGame()
    {
        SceneManager.LoadScene(3);
        Destroy(gameObject);
        FindObjectOfType<ScenePersist>().Destroying();
        scoreChecker.checker = true;
    }

    private void GameOverAnimation()
    {
        scoreChecker.checker = true;
        Destroy(pauseButton);
        Destroy(scoreChecker);
        gameOverPanel.GetComponent<Animator>().Play("GameOverPanel");
        scoreChecker.checker = true;
    }
    public void Update()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highscore", highScore);
            highScoreSee.text = highScore.ToString();
            scoreChecker.checker = true;
        }
    }
}
