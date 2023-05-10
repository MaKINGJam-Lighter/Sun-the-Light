using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private Level[] levels;

    [SerializeField]
    private GameObject zeus;

    [SerializeField]
    private GameObject apollo;

    [SerializeField]
    private Text levelUpText;

    [SerializeField]
    private AudioSource BGMAudioSource;

    [SerializeField]
    private AudioClip[] BGMClips;

    private float score;
    private bool once = true;
    private bool once2 = true;
    private bool once3 = true;
    private bool once4 = true;
    private bool once5 = true;
    private bool isZeusKilled = false;
    private bool isApolloKilled = false;

    private void Awake()
    {
        levels[0].SetLevel();
    }

    // Start is called before the first frame update
    void Start()
    {
        levels[0].SetLevel();
        BGMAudioSource.clip = BGMClips[0];
        BGMAudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        GetScore();

        if (isZeusKilled)
        {
            levels[5].SetLevel();  //마지막 레벨(무한)
            if (once)
            {
                levelUpText.enabled = true;
                Invoke("TurnOffText", 1f);
                BGMAudioSource.clip = BGMClips[5];
                BGMAudioSource.Play();
                
            }

        }
        else if(score >= 7000 && isApolloKilled)
        {
            levels[4].SetLevel();  //레벨 5, 제우스 등장
            if (once5)
            {
                levelUpText.enabled = true;
                Invoke("TurnOffText", 1f);
                zeus.SetActive(true);
                once5 = false;
                BGMAudioSource.clip = BGMClips[4];
                BGMAudioSource.Play();
            }
        }
        else if(isApolloKilled)  //레벨 4
        {
            levels[3].SetLevel();
            if (once4)
            {
                levelUpText.enabled = true;
                Invoke("TurnOffText", 1f);
                BGMAudioSource.clip = BGMClips[3];
                BGMAudioSource.Play();
            }
        } 
        else if (score >= 3000)  //레벨 3, 아폴론 등장
        {
            levels[2].SetLevel();
            if (once3)
            {
                levelUpText.enabled = true;
                Invoke("TurnOffText", 1f);
                apollo.SetActive(true);
                Debug.Log(apollo.activeSelf);
                Debug.Log("아폴론 등장");
                
                once3 = false;
                BGMAudioSource.clip = BGMClips[2];
                BGMAudioSource.Play();
            }
        }
        else if (score >= 1000)   //레벨 2
        {
            levels[1].SetLevel();
            if (once2)
            {
                levelUpText.enabled = true;
                Invoke("TurnOffText", 1f);
                BGMAudioSource.clip = BGMClips[1];
                BGMAudioSource.Play();
            }
        }
        
        isApolloKilled = GameObject.Find("GameManager").GetComponent<GameManager>().isApolloKilled;
        isZeusKilled = GameObject.Find("GameManager").GetComponent<GameManager>().isZeusKilled;
    }

    private void GetScore()
    {
        score = GameObject.Find("GameManager").GetComponent<GameManager>().score;
    }

    private void TurnOffText()
    {
        levelUpText.enabled = false;
        if (score >= 1000 && score < 3000)
        {
            once2 = false;
        }
        else if (score >= 5000 && score < 7000)
        {
            once4 = false;
        }
        else if (isZeusKilled)
        {
            once = false;
        }
        else return;
    }
}
