using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//스킵의 역할: 1. 리스타트 버튼을 부른다. 2. 페이퍼가 안 보이게 한다. 3. 버튼 커지고작아지고
public class Skip : MonoBehaviour
{
    public GameObject skip;
    public GameObject restartBtn;
    public GameObject paper;
    public GameObject toMain;
    TypingEffect scoreBoard=new TypingEffect();
    public void clickEffect()
    {
        //리스타트버튼 부르고
        restartBtn.SetActive(true);
        //메인으로 버튼도 부르고
        toMain.SetActive(true);
        //페이퍼 오브젝트는 비활성화 바이..
        paper.SetActive(false);
        //스코어보드씬
        scoreBoard.gotoScoreboard();
    }

    //마우스포인터가 위로 올라오면
    public void IfOnMousePointer()
    {
        Text btnText = skip.GetComponentInChildren<Text>();
        btnText.fontSize = 60;
    }

    //마우스포인터가 밖으로 나가면
    public void IfOutMousePointer()
    {
        Text btnText = skip.GetComponentInChildren<Text>();
        btnText.fontSize = 50;
    }
}
