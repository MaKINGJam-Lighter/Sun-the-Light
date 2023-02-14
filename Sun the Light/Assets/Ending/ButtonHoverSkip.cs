using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonHoverSkip : MonoBehaviour
{
    public GameObject skip;

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
