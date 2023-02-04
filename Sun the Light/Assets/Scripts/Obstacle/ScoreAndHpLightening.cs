using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreAndHpLightening : MonoBehaviour
{
    public Slider healthBar;
    public Text UIScore;
    public Text UIMaxScore;
    public GameManager gameManager;

    [SerializeField]
    private float score;

    [SerializeField]
    private float hp;

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
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        // DestroyObstacle();
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //playerEffectAudioSource = collision.GetComponent<AudioSource>();
            DecreaseHP();
            Debug.Log("hp 감소");
        }
        
    }

    private void DecreaseHP()
    {
        //playerEffectAudioSource.clip = hurtClip;
        //playerEffectAudioSource.Play();
        healthBar.value -= hp;
    }
}
