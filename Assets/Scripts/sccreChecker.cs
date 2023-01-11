using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sccreChecker : MonoBehaviour
{
    public static sccreChecker instance;
    public int Score;
    public int highScore;
    GameSession gameSession;
    public bool checker;

    // Start is called before the first frame update
    void Awake()
    {
        gameSession = GameObject.Find("Game Session").GetComponent<GameSession>();    
    }
    
    // Update is called once per frame
    void Update()
    {
        finding();
    }

    private void finding()
    {
        if (checker == false)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        Score = gameSession.score;
        highScore = gameSession.highScore;

    }
}
