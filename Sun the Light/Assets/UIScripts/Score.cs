using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text UIScore;
    public Text UIMaxScore;
    public GameManager gameManager;
    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        //GameManager에 point변수 있습니다. point변수 동작 따라 올려주세요
        UIScore.text = gameManager.score.ToString();
        
        UIMaxScore.text = gameManager.maxScore.ToString();
          
    }

    //죽으면(플레이어의 죽음메소드에서 호출하기) 최고점수 갱신한다. 
    //지금 점수랑 최고점수랑 비교해서 갱신
    public void CalcMaxScore()
    {
        if(gameManager.score > gameManager.maxScore) 
            gameManager.maxScore = gameManager.score;
    }
}
