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

public class ScoreBoard : MonoBehaviour
{

    private Color color = new Color(255f / 255f, 229f / 255f, 60f / 255f);//노란색
    public Text[] input_field_text;
    string id = "";
    List<string> top7_ids = new List<string>();
    bool is_typed = false;
    public static List<string> top7_scores;
    public GameObject[] scores;
    public GameObject[] Ids;
    public GameObject[] Inputs;
    int index;
    // Start is called before the first frame update
    void Start()
    {

        index = top7_scores.IndexOf((GameManager.present_score).ToString());
        //현재점수 위치로 인풋 UI이동
        for (int i = 0; i < 7; i++)
        {
            if (i == index)
            {
                continue;
            }
            Inputs[i].SetActive(false);
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
                if (Convert.ToDouble(score_and_id[0]) <= Convert.ToDouble(top7_scores[0]) && Convert.ToDouble(score_and_id[0]) >= Convert.ToDouble(top7_scores[top7_scores.Count - 1]))
                {
                    if ("" != score_and_id[1])//아이디 아직 입력 안 한 상태 대비
                    {
                        //Debug.Log("여기 들어가는지 확인");//ok
                        top7_ids.Add(score_and_id[1]);
                        for_debug_scores.Add(score_and_id[0]);
                    }
                    else//아이디 아직 안 받은 상태면
                    {
                        //Debug.Log("아이디없는 줄의 스코어: " + score_and_id[0]);//ok
                        top7_ids.Add("");//없긔
                        for_debug_scores.Add(score_and_id[0]);
                    }
                }
            }
            sr.Close();
            
            //여기문제
            //아이디 인덱스를 top7_scores 인덱스와 맞게 정렬
            for(int i = 0; i < top7_scores.Count; i++)
            {
                for (int j = 0; j < top7_scores.Count; j++)
                {
                    for (int k = 0; k < top7_scores.Count; k++)
                    {
                        if (Convert.ToDouble(for_debug_scores[j]) == Convert.ToDouble(top7_scores[k]))
                        {
                            string temp;
                            temp = for_debug_scores[j];
                            for_debug_scores[j] = for_debug_scores[k];
                            for_debug_scores[k] = temp;

                            temp = top7_ids[j];
                            top7_ids[j] = top7_ids[k];
                            top7_ids[k] = temp;
                        }
                    }
                }

            }

          
            

        }//파일 읽고 넣는 블록


        //아이디&점수 UI 변경
        for (int i = 0; i < top7_scores.Count; i++)
        {
            //텍스트변경하기
            scores[i].GetComponent<Text>().text = top7_scores[i];
            scores[i].GetComponent<Text>().color = color;
            //아이디 변경하기
            Ids[i].GetComponent<Text>().text = top7_ids[i];
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

    /*    void WriteTxt(string filePath, string message)
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(Path.GetDirectoryName(filePath));

        if (!directoryInfo.Exists)
        {
            directoryInfo.Create();
        }

        FileStream fileStream
            = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);

        StreamWriter writer = new StreamWriter(fileStream, System.Text.Encoding.Unicode);

        writer.Write(message);
        writer.Close();
    }
*/

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

    // Update is called once per frame
    void Update()
    {
        //커서 깜빡임

        if (is_typed == false && Input.GetKeyDown(KeyCode.Return))
        {
            //이러면 인풋필드에 있는 텍스트 가져와서 저장
            id = input_field_text[index].GetComponent<Text>().text;
            //아이디 이어 쓰기. ("\n"로 마무리)
            WriteTxtAppend("Assets/UIScripts/IDWithScore.txt", id + "\n");
            Inputs[index].SetActive(false);
            //눈속임
            Ids[index].GetComponent<Text>().text = id;

            is_typed = true;
        }


    }
}
