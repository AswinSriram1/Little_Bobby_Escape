using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public Text Progress;
    [SerializeField] int scenenumber;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(loadAsynchronous());
    }
    IEnumerator loadAsynchronous()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scenenumber);
        while (!operation.isDone)
        {
            float process = Mathf.Clamp01(operation.progress / .9f);
            slider.value = process;
            Progress.text = process * 100f + "%";
            yield return null;
        }
    }

}
