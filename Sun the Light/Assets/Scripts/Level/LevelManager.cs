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

    private float score;
    //private bool once = true;
    private bool once2 = true;
    private bool once3 = true;
    private bool once4 = true;
    private bool once5 = true;
   // private bool isZeusKilled = false;
    private bool isApolloKilled = false;

    private void Awake()
    {
        levels[0].SetLevel();
    }

    // Start is called before the first frame update
    void Start()
    {
        levels[0].SetLevel();
    }

    // Update is called once per frame
    void Update()
    {
        GetScore();

        if(score >= 7000 && isApolloKilled)
        {
            levels[4].SetLevel();  //레벨 5, 제우스 등장
            if (once5)
            {
                levelUpText.enabled = true;
                Invoke("TurnOffText", 1f);
                zeus.SetActive(true);
                once5 = false;
            }
        }
        else if(isApolloKilled)  //레벨 4
        {
            levels[3].SetLevel();
            if (once4)
            {
                levelUpText.enabled = true;
                Invoke("TurnOffText", 1f);
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
                Debug.Log("아폴론 등장");
                
                once3 = false;
            }
        }
        else if (score >= 1000)   //레벨 2
        {
            levels[1].SetLevel();
            if (once2)
            {
                levelUpText.enabled = true;
                Invoke("TurnOffText", 1f);
            }
        }
        isApolloKilled = GameObject.Find("GameManager").GetComponent<GameManager>().isApolloKilled;
        //isZeusKilled = GameObject.Find("GameManager").GetComponent<GameManager>().isZeusKilled;
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
        else return;
    }
}
