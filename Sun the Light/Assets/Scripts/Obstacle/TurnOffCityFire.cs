using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffCityFire : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("TurnOff", 3f);
    }

    private void TurnOff()
    {
        gameObject.SetActive(false);
    }
}
