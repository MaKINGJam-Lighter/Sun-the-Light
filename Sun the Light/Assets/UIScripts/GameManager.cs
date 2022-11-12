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
    public int score;
    public int maxScore;

    //버튼 테스트
/*    private void Start()
    {
        this.CallRestartBtn();   
    }
*/
    void Update()
    {
        //maxScore;
        //게임 했던 판들 중 가장 높은 점수를 maxScore로
        
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
    }

    //Restart버튼 클릭 시 구현되는 함수
    public void ReStart()
    {
        // 재시작하게 되면 timeScale = 1로 시간을 복구
        Time.timeScale = 1;
        SceneManager.LoadScene(0);//처음 씬으로 돌아간다.
    }

}
