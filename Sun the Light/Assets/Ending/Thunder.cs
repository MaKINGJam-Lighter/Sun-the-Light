using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Thunder : MonoBehaviour
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

    //오브젝트->컴포넌트->메소드순으로 접근해보기
    public GameObject black;
    //FadeScript black;

    int count = 0;

    private void Start()
    {
        //black = new FadeScript();
    }
    // Update is called once per frame
    void Update()
    {
        rain.GetComponent<Slider>().value += 0.05f;
        cloud.GetComponent<Slider>().value += 0.05f;
        wind.GetComponent<Slider>().value += 0.05f;
        amount.GetComponent<Slider>().value += 0.05f;

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
        //안되는부분
        /*        NullReferenceException
        UnityEngine.MonoBehaviour.StartCoroutine(System.Collections.IEnumerator routine)(at<f53c831f77784ef08ef348217b5117fa>:0)
        FadeScript.Fade()(at Assets / Ending / FadeScript.cs:17)
        Thunder.Update()(at Assets / Ending / Thunder.cs:61)*/
        if (time > 13.2f && count == 6)
        {
            //black.Fade();
            count++;
        }
        //14.2초지나면 대본띄운다.
        if (time > 14.2f && count == 7)
        {
            paper.gameObject.SetActive(true);
            text.gameObject.SetActive(true);
        }
    }
}
