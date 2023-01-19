using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private Level[] levels;

    [SerializeField]
    private GameObject zeus;

    [SerializeField]
    private Text levelUpText;

    [SerializeField]
    private AudioSource BGMAudioSource;

    [SerializeField]
    private AudioClip[] BGMClips;

    private float score;
    private bool once = true;
    private bool once2 = true;
    private bool once3 = true;
    private bool isZeusKilled = false;

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

        if (score >= 30000 || Input.GetKeyDown(KeyCode.Alpha2))
        {
            levels[2].SetLevel();
            if (once)
            {
                levelUpText.enabled = true;
                Invoke("TurnOffText", 1f);
                zeus.SetActive(true);
                once = false;
                BGMAudioSource.clip = BGMClips[1];
                BGMAudioSource.Play();
            }
        }
        else if (score >= 10000 || Input.GetKeyDown(KeyCode.Alpha1))
        {
            levels[1].SetLevel();
            if (once2)
            {
                levelUpText.enabled = true;
                Invoke("TurnOffText", 1f);
                BGMAudioSource.clip = BGMClips[0];
                BGMAudioSource.Play();
            }
        }

        if (isZeusKilled)
        {
            if (once3)
            {
                levelUpText.enabled = true;
                Invoke("TurnOffText", 1f);
                BGMAudioSource.clip = BGMClips[2];
                BGMAudioSource.Play();
            }
        }

        isZeusKilled = GameObject.Find("GameManager").GetComponent<GameManager>().isZeusKilled;
    }

    private void GetScore()
    {
        score = GameObject.Find("GameManager").GetComponent<GameManager>().score;
    }

    private void TurnOffText()
    {
        levelUpText.enabled = false;
        if (score >= 10000 && score < 30000)
        {
            once2 = false;
        }
        if (isZeusKilled)
        {
            once3 = false;
        }
    }
}
