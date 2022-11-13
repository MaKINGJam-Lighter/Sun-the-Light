using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class CallRestart : MonoBehaviour
{
    //리스타트버튼 가져오기
    public GameObject RestartButton;
/*    //텍스트 가져오기
    public GameObject gameOverMsg;
    */

    // Update is called once per frame
 
   /* //리스타트 버튼 누르면 점수화면으로
    public void ToMainGameScene()
    {

         SceneManager.LoadScene("MainGame");
    }*/


//텍스트 다 입력되면 리스타트 버튼 활성화(필요업ㅅ는메소드(
public void CallRestartBtn()
    {
        
        //버튼텍스트는 자식오브젝트이므로 InChildren 을 붙여야 함 
        Text btnText = RestartButton.GetComponentInChildren<Text>();
        btnText.text = "다시 시작";//다시시작

        RestartButton.SetActive(true);//활성화
        //여기가 문제
        //버튼 부르면 게임오버메세지도 부른다
       // gameOverMsg.SetActive(true);
    
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

        SceneManager.LoadScene("MainGame");//처음 씬으로 돌아간다.    

        //여기가 문제
        //리스타트하면 게임오버메세지도 사라진다
        //gameOverMsg.gameObject.SetActive(false);

    }
}
