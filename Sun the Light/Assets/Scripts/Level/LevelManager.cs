using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private Level[] levels;

    private float score;

    private void Awake()
    {
        levels[0].SetLevel();
    }

    // Start is called before the first frame update
    void Start()
    {
        levels[0].SetLevel();
    }

    // Update is called once per frame
    void Update()
    {
        GetScore();

        if(score >= 30000)
        {
            levels[2].SetLevel();
        }
        else if(score >= 10000)
        {
            levels[1].SetLevel();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            levels[1].SetLevel();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            levels[2].SetLevel();
        }
    }

    private void GetScore()
    {

    }
}
