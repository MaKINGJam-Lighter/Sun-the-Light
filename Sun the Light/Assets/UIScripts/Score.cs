using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text UIScore;
    public Text UIMaxScore;
    public GameManager gameManager;
    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        UIScore.text = gameManager.score.ToString();
        UIMaxScore.text = gameManager.maxScore.ToString();
    }
}
