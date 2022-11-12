using JetBrains.Annotations;
using Microsoft.Unity.VisualStudio.Editor;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class CoolTimeScript_Test : MonoBehaviour
{
    public Image image;
    public Button button;
    public float coolTime = 10.0f;
    public bool isClicked = false;
    float leftTime = 10.0f;
    float speed = 5.0f;


    void Update()
    {
        
        //클릭됐고
        if (isClicked)
        {
           
            //쿨타임 다 안 됐으면
            if (leftTime > 0)
            {
                leftTime -= Time.deltaTime * speed;//남은 시간 계속 줄어든다 
                if (leftTime < 0)//쿨타임 다 되면
                {
                    leftTime = 0;//남은시간: 0
                    if (button)
                        button.enabled = true;
                    isClicked = true;//쿨타임 다 되면 다시 클릭 활성화
                }

                //!!채우는 기능들 (이걸애니메이션으로 구현)       
                float ratio = 1.0f - (leftTime - coolTime);//채우는 양이 계속 늘어난다
                if (image)
                    image.fillAmount = ratio;//이렇게 채우는거니까
            }
        }

    }

    //클릭하면 쿨타임시작
    public void StartCoolTime()
    {
       
        leftTime = coolTime;
        isClicked = true;//클릭상태 true로 전환
        if (button)
            button.enabled = false; // 버튼 기능을 해지함.
    }
  
}
