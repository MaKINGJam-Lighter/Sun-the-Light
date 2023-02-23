using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonEventAboutPanel : MonoBehaviour
{
    public GameObject settingPanel;
    public void onOffPanel()
    {
        SceneManager.LoadScene("SoundControl");
    }

}
