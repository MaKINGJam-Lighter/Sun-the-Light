using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WholeSoundButtonEvent: MonoBehaviour
{
    public GameObject button;
    private Image buttonImage;
    private int wholeSoundIsOn=1;
    private Color color = new Color(254f/255f,206f/255f,33f/ 255f);//노란색

    private void Start()
    {
        buttonImage = button.GetComponent<Image>();
    }

    public void OnOffEvent()
    {
        wholeSoundIsOn *= -1;//-1: false, 1: true
        //색 바꾸기
        if (wholeSoundIsOn == 1)
        {
            buttonImage.color = Color.white;
        }
        else
        {
            buttonImage.color = color;
        }
    }
  

/*    public void wholeSound()
    {
        if (wholeSoundIsOn==1)//true
        {

        }
        else//false
        {

        }
    }
*/
}
