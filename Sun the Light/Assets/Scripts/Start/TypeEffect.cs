using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TypeEffect : MonoBehaviour
{
    int i = 1;
    Text tx;
    public bool done = false;
    public bool 강제done = false;
    private string Msg = "";
    public GameObject next;
    //public GameObject restartBtn;
    public GameObject paper;
    //public GameObject toMain;

    //텍스트 가져오기
    //public GameObject gameOverMsg;

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
            else{
                //이 오브젝트는 비활성화 바이..
                paper.SetActive(false);
                SceneManager.LoadScene("MainGame");
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
                //이 오브젝트는 비활성화 바이..
                paper.SetActive(false);
                SceneManager.LoadScene("MainGame");
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