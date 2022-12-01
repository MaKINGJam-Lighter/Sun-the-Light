using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manage : MonoBehaviour
{
    public float time = 0f;
    public GameObject bolt1;
    public GameObject bolt2;
    public GameObject bolt3;
    public GameObject paper;
    public GameObject text;

    public GameObject rain;
    public GameObject cloud;
    public GameObject wind;
    public GameObject amount;

    public GameObject text1;
    public GameObject text2;
    public GameObject text3;

    //여기
    public GameObject GameOverMsg;
    public GameObject RestartBtn;

    int count = 0;
    int msgCount=0;
    void Update()
    {
        rain.GetComponent<Slider>().value += 0.05f;
        cloud.GetComponent<Slider>().value += 0.05f;
        wind.GetComponent<Slider>().value += 0.05f;
        amount.GetComponent<Slider>().value += 0.05f;

        if (RestartBtn.activeSelf==true && msgCount == 0)//켜져있으면(버튼 켜져있으면)
        {
            GameOverMsg.SetActive(true);
            msgCount++;
        }

        //번개 하나당 3.336초씩(3.4씩더하자)
        time += Time.deltaTime;//1초에 60프레임    

        if (time > 1.0f && count == 0)//1초 지나면
        {
            bolt1.gameObject.SetActive(true);//첫번쨰 번개
            count++;
        }
        if (time > 4.4f && count == 1)//2초지나면
        {
            bolt1.gameObject.SetActive(false);//첫번쨰번개 끈다
            count++;
        }
        if (time > 5.4f && count == 2)//3초지나면
        {
            bolt2.gameObject.SetActive(true);//두번째번개 킨다           
            count++;
        }
        if (time > 8.8f && count == 3)//4초지나면
        {
            bolt2.gameObject.SetActive(false);//두번쨰번개 끈다
            count++;
        }
        if (time > 9.5f && count == 4)
        {
            bolt3.gameObject.SetActive(true);//세번째번개 킨다
            count++;
        }
        if (time > 12.9f && count == 5)
        {
            bolt3.gameObject.SetActive(false);//세번쨰번개 끈다
            count++;
        }
        
        //레벨 1에서 게임오버 할 떄 메세지 활성화 할 것(레벨따라 메세지 다르게)
        if(PlayerPrefs.GetInt("ClearStage")==1)
        {
            text1.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("ClearStage")==2)
        {
            text2.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("ClearStage")==3)
        {
            text3.SetActive(true);
        }



    }
}
