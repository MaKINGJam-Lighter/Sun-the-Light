﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShot : MonoBehaviour
{
    public GameObject pauseImage;

    public GameObject healthBar;
    public GameObject score;
    public GameObject maxScore;
    public GameObject skillShadow;
    public GameObject skill;

    private int isScreenShot=1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseImage.active)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                isScreenShot*=-1;
                if (isScreenShot == -1) {
                    maxScore.SetActive(false);
                    skillShadow.SetActive(false);
                    skill.SetActive(false);
                    healthBar.SetActive(false);
                    score.SetActive(false);
                }
                else
                {
                    maxScore.SetActive(true);
                    skillShadow.SetActive(true);
                    skill.SetActive(true);
                    healthBar.SetActive(true);
                    score.SetActive(true);
                }
            }

        }
        else {
            maxScore.SetActive(true);
            skillShadow.SetActive(true);
            skill.SetActive(true);
            healthBar.SetActive(true);
            score.SetActive(true);
        }
      
    }
}
