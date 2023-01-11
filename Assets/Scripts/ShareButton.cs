using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShareButton : MonoBehaviour
{
    public Button shareButton;      //Drag & Drop the Button image

    private bool isFocus = false;
    private bool isProcessing = false;

    public int scoreFinal;
    public int highscoreFinal;
    sccreChecker scoreChecker;

    void Start()
    {
        shareButton.onClick.AddListener(ShareText);
        //scoreFinal = FindObjectOfType<ScoreCaller>().caScore;
        //highscoreFinal = FindObjectOfType<ScoreCaller>().cahigScore;
        //scoreChecker = FindObjectOfType<sccreChecker>();
    }
    private void Update()
    {
        //scoreFinal = scoreChecker.Score;
        //highscoreFinal = GameObject.Find("ScoreChecker").GetComponent<sccreChecker>().highScore;
        //highscoreFinal = scoreChecker.highScore;
    }


    void OnApplicationFocus(bool focus)
    {
        isFocus = focus;
    }

    public void ShareText()        //Add this function to the button component
    {

#if UNITY_ANDROID
        if (!isProcessing)
        {
            StartCoroutine(ShareTextInAnroid());
        }
#else
		Debug.Log("No sharing set up for this platform.");
#endif
    }



#if UNITY_ANDROID
    public IEnumerator ShareTextInAnroid()
    {
        scoreFinal = FindObjectOfType<ScoreCaller>().caScore;
        highscoreFinal = FindObjectOfType<ScoreCaller>().cahigScore;

        var shareSubject = "I challenge you to find the way to exit & Beat my HighScore in Little Bobby Escape By ASR Dreams(+_+). " + "\nScore :"+ scoreFinal + "\nHighScore :"+highscoreFinal;
        var shareMessage = "I challenge you to find the way to exit & Beat my HighScore in Little Bobby Escape By ASR Dreams(+_+). " + "\nScore :" + scoreFinal + "\nHighScore :" + highscoreFinal +
                           "\nGet this Little Bobby Escape game from the link below. \nCheers\n\n" +
                           "https://play.google.com/store/apps/details?id=com.ASRDreams.LittleBobbyEscape&hl=en";

        isProcessing = true;

        if (!Application.isEditor)
        {
            //Create intent for action send
            AndroidJavaClass intentClass =
                new AndroidJavaClass("android.content.Intent");
            AndroidJavaObject intentObject =
                new AndroidJavaObject("android.content.Intent");
            intentObject.Call<AndroidJavaObject>
                ("setAction", intentClass.GetStatic<string>("ACTION_SEND"));

            //put text and subject extra
            intentObject.Call<AndroidJavaObject>("setType", "text/plain");
            intentObject.Call<AndroidJavaObject>
                ("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), shareSubject);
            intentObject.Call<AndroidJavaObject>
                ("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), shareMessage);

            //call createChooser method of activity class
            AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity =
                unity.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject chooser =
                intentClass.CallStatic<AndroidJavaObject>
                ("createChooser", intentObject, "Share your high score");
            currentActivity.Call("startActivity", chooser);
        }

        yield return new WaitUntil(() => isFocus);
        isProcessing = false;
    }
#endif
}

