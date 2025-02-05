using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wine : MonoBehaviour
{
    public Slider healthBar;
    public GameObject parent;

    [SerializeField]
    private float hp;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GameObject.FindWithTag("HP").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x > 20 || gameObject.transform.position.x < -20)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //와인 삭제
            Destroy(gameObject);
            //IncreaseHP
            IncreaseHP();

        }
    }

    private void IncreaseHP()
    {
        //playerEffectAudioSource.Play();
        healthBar.value += hp;
        Debug.Log("hp 20 증가");
    }
}