using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{
    public TypeEffect tf;
    public GameObject next;

    // Update is called once per frame
    void Update()
    {
        if(tf.done == true)
            next.SetActive(true);
    }
}
