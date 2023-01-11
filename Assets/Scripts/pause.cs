using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    public GameObject pausepanel;

    public void pauseGame()
    {
        Time.timeScale = 0f;
        pausepanel.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pausepanel.SetActive(false);
    }
}
