using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private Level[] levels;

    [SerializeField]
    private GameObject zeus;

    private float score;
    private bool once = true;

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

        if(score >= 30000)
        {
            levels[2].SetLevel();
            if (once)
            {
                zeus.SetActive(true);
                once = false;
            }
        }
        else if(score >= 10000)
        {
            levels[1].SetLevel();
        }
    }

    private void GetScore()
    {
        score = GameObject.Find("GameManager").GetComponent<GameManager>().score;
    }
}
