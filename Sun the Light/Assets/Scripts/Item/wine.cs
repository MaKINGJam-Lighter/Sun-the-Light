﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wine : MonoBehaviour
{
    public Slider healthBar;
    public GameObject parent;

    [SerializeField]
    private float hp;

<<<<<<< HEAD:Sun the Light/Assets/Scripts/Item/wine.cs
   // private float speed = parent.speed;

=======
>>>>>>> test2:Sun the Light/Assets/wine.cs
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GameObject.FindWithTag("HP").GetComponent<Slider>();
    }


    void Update()
    {
<<<<<<< HEAD:Sun the Light/Assets/Scripts/Item/wine.cs
         //gameObject.transform.Translate(-speed * Time.deltaTime, 0, 0);

         if (gameObject.transform.position.x > 20 || gameObject.transform.position.x < -20)
         {
             Destroy(gameObject);
         }
=======
        if (gameObject.transform.position.x > 20 || gameObject.transform.position.x < -20)
        {
            Destroy(gameObject);
        }
>>>>>>> test2:Sun the Light/Assets/wine.cs
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
