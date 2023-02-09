using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEventAboutPanel : MonoBehaviour
{
    public GameObject settingPanel;
    public void onOffPanel()
    {
        if(this.gameObject.name== "SettingButton")
        {
            settingPanel.SetActive(true);
        }
        else if(this.gameObject.name== "ExitButton")
        {
            settingPanel.SetActive(false);
        }
    }

}
