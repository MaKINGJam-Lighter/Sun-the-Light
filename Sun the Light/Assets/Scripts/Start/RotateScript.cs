using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    [SerializeField] [Range(1f, 100f)] float rotateSpeed = 50f;
    void Update()
    {
        transform.Rotate(0, 0, Time.deltaTime * rotateSpeed, Space.Self);
    }
}