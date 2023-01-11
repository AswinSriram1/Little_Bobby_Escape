using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdTimer : MonoBehaviour
{
    [SerializeField] float AdTime = 4f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(callAD());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator callAD()
    {
        yield return new WaitForSeconds(AdTime);
        rewardedVideo();
    }

    public void rewardedVideo()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            Advertisement.Show();
        }
    }
}
