using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GotoRankButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void gotoScoreBoard()
    {
        SceneManager.LoadScene("ScoreBoard_Button");
    }
}
