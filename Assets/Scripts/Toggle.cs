using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle : MonoBehaviour
{
    [SerializeField] GameObject oNImage;
    [SerializeField] GameObject oFFImage;

    public int counter;



    private void Start()
    {

        counter = PlayerPrefs.GetInt("num");
        Activeknow();
    }
    void Activeknow()
    {
        if (counter % 2 == 1)
        {
            oNImage.SetActive(true);
            oFFImage.SetActive(false);
            Music.instance.SetTrue();
        }
        else
        {
            oNImage.SetActive(false);
            oFFImage.SetActive(true);
            Music.instance.SetFalse();
        }
        if (counter > 10)
        {
            counter = 1;
        }
    }
    public void onclick()
    {
        counter++;
        if (counter % 2 == 1)
        {
            oNImage.SetActive(true);
            oFFImage.SetActive(false);
            Music.instance.SetTrue();

        }
        else
        {
            oNImage.SetActive(false);
            oFFImage.SetActive(true);
            Music.instance.SetFalse();
        }
        if (counter > 10)
        {
            counter = 1;
        }
        PlayerPrefs.SetInt("num", counter);
    }

}