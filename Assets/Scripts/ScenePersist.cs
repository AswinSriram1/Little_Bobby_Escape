using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePersist : MonoBehaviour
{
    int startingSceneIndex;
    sccreChecker scorechecker;

    private void Awake()
    {
        int numberScenePersist = FindObjectsOfType<ScenePersist>().Length;

        if (numberScenePersist > 1)
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
        startingSceneIndex = SceneManager.GetActiveScene().buildIndex;
        scorechecker = GameObject.Find("ScoreChecker").GetComponent<sccreChecker>();
    }

    // Update is called once per frame
    void Update()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentSceneIndex != startingSceneIndex)
        {
            Destroy(gameObject);
            scorechecker.checker = true;
        }
            
    }
    public void Destroying()
    {
        Destroy(gameObject);
        scorechecker.checker = true;
    }
}
