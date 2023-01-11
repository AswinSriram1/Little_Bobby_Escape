using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float LevelLoadDelay = 2f;
    [SerializeField] float levelExitSlowMove = 0.2f;
    sccreChecker scorechecker;

    private void Start()
    {
        //scorechecker = GameObject.Find("ScoreChecker").GetComponent<sccreChecker>();
        scorechecker = FindObjectOfType<sccreChecker>();
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(LoadNextLevel());
    }
    IEnumerator LoadNextLevel()
    {
        Time.timeScale = levelExitSlowMove;
        yield return new WaitForSecondsRealtime(LevelLoadDelay);
        Time.timeScale = 1f;

        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //SceneManager.LoadScene(currentSceneIndex + 1);
        FindObjectOfType<GameSession>().loadEndGame();
        FindObjectOfType<ScenePersist>().Destroying();
        scorechecker.checker = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
