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
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (isStart)
        {
            timer += Time.deltaTime;

            if(timer >= 2.0f)
            {
                healBar.value -= 2 * Time.deltaTime;

                if (!isSoundPlay)
                {
                    audioSource.Play();
                    isSoundPlay = true;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isSoundPlay = false;
            isStart = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isSoundPlay = false;
            isStart = false;
            timer = 0;
        }
    }
}
