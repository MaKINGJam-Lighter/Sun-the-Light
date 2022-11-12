using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    //리스타트버튼 가져오기
    public GameObject RestartButton;
    //플레이어가 뭐 하면 포인트올라가게(플레이어에서 포인트 불러와서 올리기)
    public int score=0;
    public int maxScore;
    public Text gameOverMsg;

   
    void Update()
    {
        //리스타트버튼 테스트>된다!
        if (Input.GetKeyDown(KeyCode.R)){
            CallRestartBtn();
        }        
    }
    //플레이어 죽으면(플레이어 죽을 때의 메소드에서 이 메소드 호출)
    public void CallRestartBtn()
    {
        //플레이어컨트롤 lock
        Time.timeScale = 0;
        //리스타트 버튼 ui
        RestartButton.SetActive(true);
    
        
        //버튼텍스트는 자식오브젝트이므로 InChildren 을 붙여야 함 
        Text btnText = RestartButton.GetComponentInChildren<Text>();
        btnText.text = "다시 시작";//다시시작

        RestartButton.SetActive(true);

        //여기가 문제
        //버튼 부르면 게임오버메세지도 부른다
        gameOverMsg.gameObject.SetActive(true);//여기가 안된다.
    }

    //마우스포인터가 위로 올라오면
    public void IfOnMousePointer()
    {
        Text btnText = RestartButton.GetComponentInChildren<Text>();
        btnText.fontSize = 60;
    }

    //마우스포인터가 밖으로 나가면
    public void IfOutMousePointer()
    {
        Text btnText = RestartButton.GetComponentInChildren<Text>();
        btnText.fontSize = 50;
    }

    //Restart버튼 클릭 시 구현되는 함수(유니티 클릭시()에 넣어주자)
    public void ReStart()
    {


        // 재시작하게 되면 timeScale = 1로 시간을 복구
        Time.timeScale = 1;
        SceneManager.LoadScene(0);//처음 씬으로 돌아간다.
        score = 0;//재시작버튼 누르면 score 0으로 초기화
        

        //여기가 문제
        //리스타트하면 게임오버메세지도 사라진다
        //gameOverMsg.gameObject.SetActive(false);
      
    }

}
