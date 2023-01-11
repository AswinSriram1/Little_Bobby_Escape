using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    sccreChecker scorechecker;

    private void Start()
    {
        //scorechecker = GameObject.Find("ScoreChecker").GetComponent<sccreChecker>();
        scorechecker = FindObjectOfType<sccreChecker>();
    }
    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadMenu()
    {
        sccreChecker.instance.checker = true;
        SceneManager.LoadScene(0);
    }
    public void Quitting()
    {
        Application.Quit();
    }
    public void menu()
    {
        SceneManager.LoadScene(0);
    }
}
