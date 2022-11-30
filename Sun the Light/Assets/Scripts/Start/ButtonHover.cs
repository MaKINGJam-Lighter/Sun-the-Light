using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonHover : MonoBehaviour
{
    public Text btnText;

    //마우스포인터가 위로 올라오면
    public void EnterButton()
    {
        btnText.fontSize += 10;
    }

    //마우스포인터가 밖으로 나가면
    public void LeaveButton()
    {
        btnText.fontSize -= 10;
    }

}
