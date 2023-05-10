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

public class ScoreBoard_Button : MonoBehaviour
{

    private Color color = new Color(255f / 255f, 229f / 255f, 60f / 255f);//노란색
    string id = "";
    List<string> top7_ids_List = new List<string>();
    bool is_typed = false;
    public static List<string> top7_scores_List;
    public GameObject[] scores_UI;
    public GameObject[] Ids_UI;
    int index;
    string read_line = "";

    //텍스트 가져오기
    //스코어보드
    List<string> scores_List = new List<string>();
    List<string> top7_scores_nonstatic = new List<string>();


    // Start is called before the first frame update
    void Start()
    {
        {
            StreamReader sr = new StreamReader(new FileStream("Assets/UIScripts/ScoreText.txt", FileMode.Open));
            while (sr.EndOfStream == false) // 스트림의 끝에 도달했는지 알려주는 EndOfStream 프로퍼티
            {
                read_line = sr.ReadLine();
                scores_List.Add(read_line);
            }
            sr.Close();
        }
        //상위 7개 추린다.(현재 점수가 상위 7개보다 높은지 비교하기위해서)
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


        string id = "";
        //id 리스트에 id들 다 넣는다. 
        {
            List<string> for_debug_scores = new List<string>();
            StreamReader sr = new StreamReader(new FileStream("Assets/UIScripts/IDWithScore.txt", FileMode.Open));
            while (sr.EndOfStream == false) // 스트림의 끝에 도달했는지 알려주는 EndOfStream 프로퍼티
            {
                string line = sr.ReadLine();
                string[] score_and_id;
                score_and_id = line.Split('\t');

                //Debug.Log("top7_scores꼴찌순위: "+top7_scores[top7_scores.Count - 1]);//ok
                //만약 IDWithScore에서 읽은 점수가 top7에 들어가면,그 때 아이디 반영
                if (Convert.ToDouble(score_and_id[0]) <= Convert.ToDouble(top7_scores_nonstatic[0]) && Convert.ToDouble(score_and_id[0]) >= Convert.ToDouble(top7_scores_nonstatic[top7_scores_nonstatic.Count - 1]))
                {
                    if ("" != score_and_id[1])//아이디 아직 입력 안 한 상태 대비
                    {
                        top7_ids_List.Add(score_and_id[1]);
                        for_debug_scores.Add(score_and_id[0]);
                    }
                }
            }
            sr.Close();

            //여기문제
            //아이디 인덱스를 top7_scores 인덱스와 맞게 정렬
            for (int i = 0; i < top7_scores_nonstatic.Count; i++)
            {
                for (int j = 0; j < top7_scores_nonstatic.Count; j++)
                {
                    for (int k = 0; k < top7_scores_nonstatic.Count; k++)
                    {
                        if (Convert.ToDouble(for_debug_scores[j]) == Convert.ToDouble(top7_scores_nonstatic[k]))
                        {
                            string temp;
                            temp = for_debug_scores[j];
                            for_debug_scores[j] = for_debug_scores[k];
                            for_debug_scores[k] = temp;

                            temp = top7_ids_List[j];
                            top7_ids_List[j] = top7_ids_List[k];
                            top7_ids_List[k] = temp;
                        }
                    }
                }

            }




        }//파일 읽고 넣는 블록


        //아이디&점수 UI 변경
        for (int i = 0; i < top7_scores_nonstatic.Count; i++)
        {
            //텍스트변경하기
            scores_UI[i].GetComponent<Text>().text = top7_scores_nonstatic[i];
            scores_UI[i].GetComponent<Text>().color = color;
            //아이디 변경하기
            Ids_UI[i].GetComponent<Text>().text = top7_ids_List[i];
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
