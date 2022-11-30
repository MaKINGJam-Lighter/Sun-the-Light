using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    private Animator fadeInOutPanel;

    public void GoHome()
    {
        fadeInOutPanel.SetBool("isFadeOut", true);
        Invoke("DelayGoHome", 1f);
    }

    public void GoStartAnimation()
    {
        fadeInOutPanel.SetBool("isFadeOut", true);
        Invoke("DelayGoStartAnimation", 1f);
    }

    public void GoHowToPlay()
    {
        fadeInOutPanel.SetBool("isFadeOut", true);
        Invoke("DelayGoHowToPlay", 1f);
    }

    public void GoInfo()
    {
        fadeInOutPanel.SetBool("isFadeOut", true);
        Invoke("DelayGoInfo", 1f);
    }

    public void GoMainGame()
    {
        fadeInOutPanel.SetBool("isFadeOut", true);
        Invoke("DelayGoMainGame", 1f);
    }

    public void GoOverGame()
    {
        fadeInOutPanel.SetBool("isFadeOut", true);
        Invoke("DelayGoOverGame", 1f);
    }

    public void GoClearGame()
    {
        fadeInOutPanel.SetBool("isFadeOut", true);
        Invoke("DelayGoClearGame", 1f);
    }

    public void GoSoundControl()
    {
        fadeInOutPanel.SetBool("isFadeOut", true);
        Invoke("DelayGoSoundControl", 1f);
    }


    public void DelayGoHome()
    {
        SceneManager.LoadScene("Home");
    }

    public void DelayGoStartAnimation()
    {
        SceneManager.LoadScene("StartAnimation");
    }

    public void DelayGoHowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void DelayGoInfo()
    {
        SceneManager.LoadScene("GoInfo");
    }

    public void DelayGoMainGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void DelayGoOverGame()
    {
        SceneManager.LoadScene("OverGame");
    }

    public void DelayGoClearGame()
    {
        SceneManager.LoadScene("ClearGame");
    }

    public void DelayGoSoundControl()
    {
        SceneManager.LoadScene("SoundControl");
    }
}