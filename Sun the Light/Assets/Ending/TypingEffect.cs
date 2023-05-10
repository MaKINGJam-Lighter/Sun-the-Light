using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class TypingEffect : MonoBehaviour
{
    int i = 1;
    Text tx;
    bool done = false;
    bool 강제done = false;
    private string Msg = "";
    public GameObject next;
    public GameObject restartBtn;
    public GameObject paper;
    public GameObject toMain;

    //텍스트 가져오기
    //public GameObject gameOverMsg;
    //스코어보드
    public List<string> scores = new List<string>();
    public List<string> top7_scores = new List<string>();
     ScoreBoard scoreboard = new ScoreBoard();
    public static int present_score_index;

    public void gotoScoreboard()
    {
        string read_line = "";

        //scores 리스트에 점수들 다 넣는다.
        int k = 0;
        StreamReader sr = new StreamReader(new FileStream("Assets/UIScripts/ScoreText.txt", FileMode.Open));
        while (sr.EndOfStream == false) // 스트림의 끝에 도달했는지 알려주는 EndOfStream 프로퍼티
        {
            read_line = sr.ReadLine();
            scores.Add(read_line);
        }
        sr.Close();

        //상위 7개 추린다.(현재 점수가 상위 7개보다 높은지 비교하기위해서)
        //점수안에 7개 이상 있으면
        if (scores.Count >= 7)
        {
            double highest = 0;
            for (int i = 0; i < 7; i++)
            {
                highest = 0;
                for (int j = 0; j <= scores.Count - 1; j++)
                {
                    if (Convert.ToDouble(scores[j]) > highest)
                    {
                        highest = Convert.ToDouble(scores[j]);
                    }
                }
                //scores에서 가장 높은거 top7_scores에 넣고 지우는거 반복
                top7_scores.Add(highest.ToString());
                scores.Remove(highest.ToString());//지운다. (다음 높은거 추려야하니까)
            }
            //top7 내림차순정렬
            for (int i = 0; i < top7_scores.Count - 1; i++)
            {
                for (int j = i + 1; j < top7_scores.Count; j++)
                {
                    if (Convert.ToDouble(top7_scores[i]) < Convert.ToDouble(top7_scores[j]))
                    {
                        top7_scores[i] = top7_scores[j];
                    }
                }
            }
          

            //상위 7개 추렸으니, 현재점수가 그 안에 들어가는지 체크
            if (GameManager.is_repititive==false&&(double)GameManager.present_score >= Convert.ToDouble(top7_scores[6]))
            {
                //상위7개 저장& 7위보다 높은 점수면 스코어보드 씬으로 이동
                ScoreBoard.top7_scores = top7_scores;
                //IDWithScore에 일단 지금 점수 적어놓음(스코어보드 씬에서 아이디도 이어 적음. )
                //구분문자: \t
                scoreboard.WriteTxtAppend("Assets/UIScripts/IDWithScore.txt", GameManager.present_score.ToString() + "\t");
                SceneManager.LoadScene("ScoreBoard");
            }
        }
        else//점수안에 7개 미만이면
        {
            double highest = 0;//가장높은 수 저장
            //7갠지 몇갠지 모르니까 count만큼
            int start_i_range = scores.Count;
            for (int i = 0; i < start_i_range; i++)
            {
                highest = 0;
                for (int j = 0; j <= scores.Count - 1; j++)
                {

                    if (Convert.ToDouble(scores[j]) > highest)
                    {
                        highest = Convert.ToDouble(scores[j]);
                    }
                }

                //scores에서 가장 높은거 top7_scores에 넣고 지우는거 반복
                top7_scores.Add(highest.ToString());
                scores.Remove(highest.ToString());
               
            }

            //top7 내림차순정렬
            for (int i = 0; i < top7_scores.Count - 1; i++)
            {
                for (int j = i + 1; j < top7_scores.Count; j++)
                {
                    if (Convert.ToDouble(top7_scores[i]) < Convert.ToDouble(top7_scores[j]))
                    {
                        top7_scores[i] = top7_scores[j];
                    }
                }
            }

         

            //상위n개 저장& 바로 스코어보드 씬으로 이동
            ScoreBoard.top7_scores = top7_scores;
            if (GameManager.is_repititive == false)
            {
                scoreboard.WriteTxtAppend("Assets/UIScripts/IDWithScore.txt", GameManager.present_score.ToString() + "\t");
                SceneManager.LoadScene("ScoreBoard");
            }

        }

    }

    void Start()
    {
        tx = GetComponent<Text>();
        Msg = tx.text;//메세지는 텍스트의 텍스트를 전부 가진다.
        tx.enabled = true;//스타트하면 텍스트 가져와서 활성화
        StartCoroutine(_typing());
    }

    void Update()
    {
        //여기에다가 스페이스바로 강제종료했는지 판단하는 코드를 넣기
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //강제종료 했으면 
            i *= -1;//한번 누르면 -1, 두 번 누르면 +1
            강제done = true;
            tx.text = Msg.Substring(0, 0);//타이핑하던거 지우고(타이핑 메소드 중지하기)
            tx.text = Msg;//텍스트 전부 갖고오기
            더블스페이스();
        }

        //텍스트가 자연스럽게 끝날 경우
        else if (done == true)//텍스트 끝나면
        {
            tx.enabled = false;//현재 텍스트 비활성화
            if (next)//다음 텍스트가 있으면
                next.SetActive(true);//다음 텍스트를 활성화
            else//타이핑 끝나면 리스타트버튼 활성화, paper비활성화
            {
                //리스타트버튼 부르고
                restartBtn.SetActive(true);
                //메인으로 버튼도 부르고
                toMain.SetActive(true);
                //이 오브젝트는 비활성화 바이..
                paper.SetActive(false);
                //스코어보드씬
                gotoScoreboard();
            }
        }
    }

    void 더블스페이스()
    {
        if (i > 0)//if (Input.GetKeyDown(KeyCode.Space)) 하면 안 되는 이유: update에서 호출하니까 한 프레임 안에 있음-> 똑같이 인식-> if(스페이스)한 문장들은 와라락 다 실행됨
        {
            //프레임이 분리되어야 한다->-1과 1로 분리
            tx.enabled = false;//현재 텍스트 비활성화
            if (next)//다음 텍스트가 있으면
                next.SetActive(true);//다음 텍스트를 활성화
            else//타이핑 끝나면 리스타트버튼 활성화, paper비활성화
            {
                //리스타트버튼 부르고
                restartBtn.SetActive(true);
                //메인으로 버튼도 부르고
                toMain.SetActive(true);
                //이 오브젝트는 비활성화 바이..
                paper.SetActive(false);
                //스코어보드씬
                gotoScoreboard();
            }
        }
    }

    IEnumerator _typing()
    {
        for (int i = 0; i <= Msg.Length; i++)
        {
            if (강제done == true)
                break;
            tx.text = Msg.Substring(0, i);
            if (i == Msg.Length)
                done = true;
            yield return new WaitForSeconds(0.075f);
        }
    }

}