using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCaller : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI endScore;
    [SerializeField] TextMeshProUGUI endHighScore;
    sccreChecker sccreChecker;
    public int caScore;
    public int cahigScore;
    // Start is called before the first frame update
    void Start()
    {
        caScore = FindObjectOfType<sccreChecker>().Score;
        cahigScore = FindObjectOfType<sccreChecker>().highScore;
        sccreChecker = FindObjectOfType<sccreChecker>();
    }

    // Update is called once per frame
    void Update()
    {
        endScore.text = caScore.ToString();
        endHighScore.text = cahigScore.ToString();
        sccreChecker.checker = true;
    }
}
