using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreAndHp : MonoBehaviour
{
    public Slider healthBar;
    public Text UIScore;
    public Text UIMaxScore;
    public GameManager gameManager;

    [SerializeField]
    private float score;

    [SerializeField]
    private float hp;

    [SerializeField]
    private AudioClip destroyClip;

    private AudioSource effectAudioSource;

    public float GetScore()
    {
        return score;
    }

    public float GetHp()
    {
        return hp;
    }

    private void Start()
    {
        effectAudioSource = GameObject.Find("Effect Audio Source").GetComponent<AudioSource>();
        healthBar = GameObject.FindWithTag("HP").GetComponent<Slider>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DestroyObstacle();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            DestroyObstacle();
            DecreaseHP();
        }
        else if(collision.tag == "Skill")
        {
            DestroyObstacle();
            IncreaseScore();
            Destroy(collision.gameObject);
        }
    }

    private void DestroyObstacle()
    {
        gameObject.GetComponent<Animator>().SetBool("isDestroy", true);
        effectAudioSource.clip = destroyClip;
        effectAudioSource.Play();
    }

    private void DecreaseHP()
    {
        healthBar.value -= hp;
    }

    private void IncreaseScore()
    {
        gameManager.score += score;

        if(gameManager.maxScore < gameManager.score)
        {
            gameManager.maxScore = gameManager.score;
        }
    }
}
