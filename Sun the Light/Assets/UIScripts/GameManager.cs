using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.IO;
using JetBrains.Annotations;

public class GameManager : MonoBehaviour
{
    public static bool is_repititive=false;
    private bool is_typed=false;
    public static float present_score=0;
    public Slider health_bar;
    //플레이어가 뭐 하면 포인트올라가게(플레이어에서 포인트 불러와서 올리기)
    public float score=0;
    public float maxScore = 0;
    public bool isZeusKilled = false;
    public bool isApolloKilled = false;
    ScoreBoard score_board = new ScoreBoard();
    private void Start()
    {
        present_score = 0;
        is_repititive = false;
        maxScore = Single.Parse(PlayerPrefs.GetString("MaxScore"));
    }

    void Update()
    {
        present_score = score;
        //죽으면 점수 파일에 쓰기(이미 있는 점수면 쓰지x)
        if (health_bar.value <= 0&&is_typed==false)
        {
            bool isDuplication = false;
            StreamReader sr = new StreamReader(new FileStream("Assets/UIScripts/ScoreText.txt", FileMode.Open));
            while (sr.EndOfStream == false) // 스트림의 끝에 도달했는지 알려주는 EndOfStream 프로퍼티
            {
                string read_line = sr.ReadLine();
                //중복되면
                if (Convert.ToDouble(read_line) == present_score)
                {
                    isDuplication = true;
                }
            }
            //sr.Close();
            if (isDuplication == false)
            {
                //here
                Debug.Log("GameManager 스크립트: 중복x->파일쓰기");
                score_board.WriteTxtAppend("Assets/UIScripts/ScoreText.txt", present_score.ToString() + "\n");
            }
            else
            {
                is_repititive = true;
            }
            is_typed = true;
            sr.Close();
        }
    }
}
