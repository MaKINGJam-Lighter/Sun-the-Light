using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class 메인으로 : MonoBehaviour
{

    public GameObject toMain;
    public void clickEffect()
    {
        //버튼 누르면 메인 씬 호출
        SceneManager.LoadScene("Home");//처음 씬으로 돌아간다.    

    }

    //마우스포인터가 위로 올라오면
    public void IfOnMousePointer()
    {
        Text btnText = toMain.GetComponentInChildren<Text>();
        btnText.fontSize = 60;
    }

    //마우스포인터가 밖으로 나가면
    public void IfOutMousePointer()
    {
        Text btnText = toMain.GetComponentInChildren<Text>();
        btnText.fontSize = 50;
    }
}
