using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    
    
    //플레이어가 뭐 하면 포인트올라가게(플레이어에서 포인트 불러와서 올리기)
    public float score=0;
    public float maxScore = 0;
    public bool isZeusKilled = false;
  

    private void Start()
    {
        maxScore = Single.Parse(PlayerPrefs.GetString("MaxScore"));
    }



    void Update()
    {
              
    }
}
