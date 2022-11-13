using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreAndHPForZeus : MonoBehaviour
{
    public Slider healthBar;
    public GameManager gameManager;

    [SerializeField]
    private float score;

    [SerializeField]
    private float hp;

    [SerializeField]
    private Slider hpBar;

    [SerializeField]
    private float attackPower;

    [SerializeField]
    private Animator zeusAnimator;

    [SerializeField]
    private AudioClip destroyClip;

    [SerializeField]
    private AudioClip hurtClip;

    [SerializeField]
    private bool isZeus;

    private AudioSource playerEffectAudioSource;
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
        effectAudioSource = GetComponent<AudioSource>();
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
        if (collision.tag == "Player")
        {
            playerEffectAudioSource = collision.GetComponent<AudioSource>();
            DecreaseHP();
        }
        else if (collision.tag == "Skill")
        {
            hpBar.value -= attackPower;
            IncreaseScore();

            if (hpBar.value == 0)
            {
                if (isZeus)
                {
                    gameManager.score += 1500;
                    isZeus = false;
                    Debug.Log("clear score");
                }
                zeusAnimator.SetBool("isDead", true);
                Destroy(collision.gameObject);
                Invoke("DestroyObstacle", 1f);
            }
            else
            {
                //effectAudioSource.clip = destroyClip;
                //effectAudioSource.Play();
            }
        }
    }

    private void DestroyObstacle()
    {
        Destroy(gameObject);
        //effectAudioSource.clip = destroyClip;
        //effectAudioSource.Play();
    }

    private void DecreaseHP()
    {
        playerEffectAudioSource.clip = hurtClip;
        playerEffectAudioSource.Play();
        healthBar.value -= hp;
    }

    private void IncreaseScore()
    {
        gameManager.score += score;

        if (gameManager.maxScore < gameManager.score)
        {
            gameManager.maxScore = gameManager.score;
        }
    }
}
