using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    private Animator fadeInOutPanel;
    public static bool is_pushed_for_RankScene=false;
    private void Start()
    {
        is_pushed_for_RankScene = false;
    }
    public void GoHome()
    {
        fadeInOutPanel.SetBool("isFadeOut", true);
        Invoke("DelayGoHome", 1f);
        is_pushed_for_RankScene = true;
    }

    public void GoStartAnimation()
    {
        fadeInOutPanel.SetBool("isFadeOut", true);
        Invoke("DelayGoStartAnimation", 1f);
        is_pushed_for_RankScene = true;
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
}