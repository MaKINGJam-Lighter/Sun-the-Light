using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CityTrigger : MonoBehaviour
{
    [SerializeField]
    private Slider healBar;

    private bool isStart = false;
    private float timer = 0f;
    private bool isSoundPlay = false;

    [SerializeField]
    private AudioSource starAudioSource;

    [SerializeField]
    private AudioSource cityAudioSource;

    [SerializeField]
    private AudioSource playerAudioSource;

    [SerializeField]
    private AudioClip hurtClip;

    [SerializeField]
    private GameObject cityFire;

    private AudioSource star;

    // Start is called before the first frame update
    void Start()
    {
        star = GameObject.FindWithTag("Star").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isStart)
        {
            timer += Time.deltaTime;

            if(timer >= 2.0f)
            {
                healBar.value -= 2f * Time.deltaTime;

                if (!playerAudioSource.isPlaying)
                {
                    playerAudioSource.clip = hurtClip;
                    playerAudioSource.Play();
                }

                if (!isSoundPlay && GameObject.FindWithTag("Player").transform.position.y > 0)
                {
                    starAudioSource.Play();
                    isSoundPlay = true;
                }
                else if(!isSoundPlay && GameObject.FindWithTag("Player").transform.position.y < 0)
                {
                    cityFireActive();
                    isSoundPlay = true;
                }
                else if (isSoundPlay && GameObject.FindWithTag("Player").transform.position.y < 0)
                {
                    Invoke("cityFireActive", 3f);
                }
            }
        }
    }

    private void cityFireActive()
    {
        cityFire.SetActive(true);
        cityFire.transform.position = new Vector3(GameObject.FindWithTag("Player").transform.position.x, -4.2f, 0);
        cityAudioSource.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isSoundPlay = false;
            isStart = true;
            star.loop = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            cityFire.SetActive(false);
            isSoundPlay = false;
            isStart = false;
            timer = 0;
            star.loop = false;
            star.Stop();
        }
    }
}
