using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreAndHp : MonoBehaviour
{
    
    public Text UIScore;
    public Text UIMaxScore;
    public GameManager gameManager;

    public Slider healthBar;

    [SerializeField]
    public GameObject wine;

    [SerializeField]
    private float score;

    [SerializeField]
    private float hp;

    [SerializeField]
    private int life;

    [SerializeField]
    private AudioClip destroyClip;

    [SerializeField]
    private AudioClip hurtClip;

    [SerializeField]
    //private GameObject wine;

    private AudioSource playerEffectAudioSource;
    private AudioSource effectAudioSource;

    private float rand;

    [SerializeField]
    private GameObject parent;

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

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerEffectAudioSource = collision.GetComponent<AudioSource>();
            DestroyObstacle();
            DecreaseHP();
        }
        else if(collision.tag == "Skill")
        {
            life -= 1;
            if (life == 0)
            {
                DestroyObstacle();
                IncreaseScore();
                Destroy(collision.gameObject);
                rand = Random.Range(0f, 100f);
                if (rand <= 7f)  //7프로의 확률
                {
                    GameObject.Instantiate(wine, transform.position, Quaternion.identity).transform.parent = parent.transform;
                    //Instantiate(wine, transform.position, Quaternion.identity);
                }
            }
            else
            {
                if (destroyClip != null)
                {
                    effectAudioSource.clip = destroyClip;
                    effectAudioSource.Play();
                }
            }
        }
    }

    public void Wine()
    {
        float ran = Random.Range(0, 99);
        Debug.Log(ran);
        if(ran<7)
        {
            //Instantiate(wine);
            Instantiate(wine, gameObject.transform.position, Quaternion.identity);
            //wine.transform.SetParent(parent.transform, false);
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
        playerEffectAudioSource.clip = hurtClip;
        playerEffectAudioSource.Play();
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
