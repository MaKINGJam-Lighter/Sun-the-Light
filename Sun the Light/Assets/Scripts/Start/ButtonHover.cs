using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonHover : MonoBehaviour
{

    //마우스포인터가 위로 올라오면
    public void EnterButton()
    {
        GameObject Button = this.gameObject;
        if (Button)
        {
            Text btnText = Button.GetComponentInChildren<Text>();
            btnText.fontSize = 60;
        }
 
    }

    //마우스포인터가 밖으로 나가면
    public void LeaveButton()
    {
        GameObject Button = this.gameObject;
        if (Button)
        {
            Text btnText = Button.GetComponentInChildren<Text>();
            btnText.fontSize = 50;
        }
    }

}
