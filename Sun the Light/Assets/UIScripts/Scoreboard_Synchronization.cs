using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

public class Scoreboard_Synchronization : MonoBehaviour
{

    string read_line = "";

    //텍스트 가져오기
    //스코어보드
    List<string> scores_List = new List<string>();
    List<string> top7_scores_nonstatic = new List<string>();
    List<int> top7_IdWithScoreText= new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        //1. score text 상위 7개 추리기
        {
            StreamReader sr = new StreamReader(new FileStream("Assets/UIScripts/ScoreText.txt", FileMode.Open));
            while (sr.EndOfStream == false) // 스트림의 끝에 도달했는지 알려주는 EndOfStream 프로퍼티
            {
                read_line = sr.ReadLine();
                scores_List.Add(read_line);
            }
            sr.Close();
        }
        //점수안에 7개 이상 있으면
        if (scores_List.Count >= 7)
        {
            double highest = 0;
            for (int i = 0; i < 7; i++)
            {
                highest = 0;
                for (int j = 0; j <= scores_List.Count - 1; j++)
                {
                    if (Convert.ToDouble(scores_List[j]) > highest)
                    {
                        highest = Convert.ToDouble(scores_List[j]);
                    }
                }
                //scores에서 가장 높은거 top7_scores에 넣고 지우는거 반복
                top7_scores_nonstatic.Add(highest.ToString());
                scores_List.Remove(highest.ToString());//지운다. (다음 높은거 추려야하니까)
            }
            //top7 내림차순정렬
            for (int i = 0; i < top7_scores_nonstatic.Count - 1; i++)
            {
                for (int j = i + 1; j < top7_scores_nonstatic.Count; j++)
                {
                    if (Convert.ToDouble(top7_scores_nonstatic[i]) < Convert.ToDouble(top7_scores_nonstatic[j]))
                    {
                        top7_scores_nonstatic[i] = top7_scores_nonstatic[j];
                    }
                }
            }


        }
        else//점수안에 7개 미만이면
        {
            double highest = 0;//가장높은 수 저장
                               //7갠지 몇갠지 모르니까 count만큼
            int start_i_range = scores_List.Count;
            for (int i = 0; i < start_i_range; i++)
            {
                highest = 0;
                for (int j = 0; j <= scores_List.Count - 1; j++)
                {

                    if (Convert.ToDouble(scores_List[j]) > highest)
                    {
                        highest = Convert.ToDouble(scores_List[j]);
                    }
                }

                //scores에서 가장 높은거 top7_scores에 넣고 지우는거 반복
                top7_scores_nonstatic.Add(highest.ToString());
                scores_List.Remove(highest.ToString());
            }

            //top7 내림차순정렬
            for (int i = 0; i < top7_scores_nonstatic.Count - 1; i++)
            {
                for (int j = i + 1; j < top7_scores_nonstatic.Count; j++)
                {
                    if (Convert.ToDouble(top7_scores_nonstatic[i]) < Convert.ToDouble(top7_scores_nonstatic[j]))
                    {
                        top7_scores_nonstatic[i] = top7_scores_nonstatic[j];
                    }
                }
            }

        }

        //2. IDWithScore top7 점수랑 비교
        {
            StreamReader sr = new StreamReader(new FileStream("Assets/UIScripts/IDWithScore.txt", FileMode.Open));
            while (sr.EndOfStream == false) // 스트림의 끝에 도달했는지 알려주는 EndOfStream 프로퍼티
            {
                string line = sr.ReadLine();
                Debug.Log("line: " + line);
                string[] score_and_id;
                score_and_id = line.Split('\t');
                top7_IdWithScoreText.Add(int.Parse(score_and_id[0]));
            }
            sr.Close();
            //내림차순정렬
            top7_IdWithScoreText.Sort();
            top7_IdWithScoreText.Reverse();
            top7_IdWithScoreText.RemoveRange(7, top7_IdWithScoreText.Count - 7);//첫번째인자: 삭제시작 인덱스, 두번째인자: 삭제할갯수
        }//파일 읽고 넣는 블록

        //scoretext상위 7개가 IdWithText상위 7개랑 일치하는지 비교
        //scoretext의 점수가 idWithText에 없으면 idWithText에 쓰기.  
        bool isExist = false;
        for (int i = 0; i < 7; i++) {
            for (int j = 0; j < 7; j++) {
                if (top7_scores_nonstatic[i] == top7_IdWithScoreText[j].ToString()) {
                    isExist = true;
                }
            }
            if (!isExist)
            {
                WriteTxtAppend("Assets/UIScripts/IDWithScore.txt", top7_scores_nonstatic[i] + "\t"+" "+"\n");
            }
        }


    }
    public void WriteTxtAppend(string filePath, string message)
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(Path.GetDirectoryName(filePath));

        if (!directoryInfo.Exists)
        {
            directoryInfo.Create();
        }

        StreamWriter writer = new StreamWriter(filePath, true, System.Text.Encoding.Unicode);

        writer.Write(message);
        writer.Close();
    }



    public string ReadAllTxt(string filePath)
    {
        FileInfo fileInfo = new FileInfo(filePath);
        string value = "";

        if (fileInfo.Exists)
        {
            StreamReader reader = new StreamReader(filePath);
            value = reader.ReadToEnd();
            reader.Close();
        }

        else
            value = "파일이 없습니다.";

        return value;
    }

}
