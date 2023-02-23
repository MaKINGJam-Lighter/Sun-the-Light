using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WholeSoundButtonEvent: MonoBehaviour
{
    public static bool Bgm=true;//static: 프로그램이 종료될 때 해제. 클래스메모리
    public static bool Effect=true;

    public GameObject button;
    private Image buttonImage;
    private int wholeSoundIsOn=1;
    private Color color = new Color(113f/255f,140f/255f,225f/ 255f);//파란색

    private void Start()
    {
        buttonImage = button.GetComponent<Image>();

        if (this.gameObject.name == "BGMButton")
        {
            if (Bgm)
            {
                buttonImage.color = Color.white;
            }
            else
            {
                buttonImage.color = color;
            }
        }
        if (this.gameObject.name == "EffectButton")
        {
            if (Effect)
            {
                buttonImage.color = Color.white;
            }
            else
            {
                buttonImage.color = color;
            }
        }
    }
   /* private void Update()
    {
        print(wholeSoundIsOn);
    }*/

    public void OnOffEvent()
    {
        wholeSoundIsOn *= -1;//-1: false, 1: true
        //색 바꾸기
        if (wholeSoundIsOn == 1)
        {
            buttonImage.color = Color.white;
            if (this.gameObject.name== "BGMButton")
            {
                Bgm = true;
            }
            if (this.gameObject.name == "EffectButton")
            {
                Effect = true;
            }
        }
        else
        {
            buttonImage.color = color;
            if (this.gameObject.name == "BGMButton")
            {
                Bgm = false;
            }
            if (this.gameObject.name == "EffectButton")
            {
                Effect = false;
            }
        }
    }

}
