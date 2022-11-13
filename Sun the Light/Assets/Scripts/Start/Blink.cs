using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinking : MonoBehaviour
{
    Animator BlinkPanel;

    void Awake()
    {
        BlinkPanel = gameObject.transform.GetComponent<Animator>();
        BlinkPanel.SetBool("isActive", true);
    }
}
