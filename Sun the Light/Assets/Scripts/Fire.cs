﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public int dmg;
    //public bool isRotate;

    void Update()
    {
        //if (isRotate)
       //{
            //transform.Rotate(Vector3.forward * 10);
       // }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "BorderFire")
        {
            Destroy(gameObject);
        }
    }
}
