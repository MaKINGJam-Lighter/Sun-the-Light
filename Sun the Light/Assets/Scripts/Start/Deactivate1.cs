using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate1 : MonoBehaviour
{
    public TypeEffect tf;
    public GameObject next;

    // Update is called once per frame
    void Update()
    {
        if (tf.done == true)
            Invoke("deactive", 0.1f);
    }

    private void deactive()
    {
        next.SetActive(false);
    }
}
